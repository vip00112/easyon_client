using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace EasyOn {
    class Worker {
        private static readonly Worker instance = new Worker();

        public static Worker getInstance() {
            return instance;
        }

        private static readonly int MAX_SIZE = 1024 * 1024; // 수신 버퍼 최대 크기

        private int _type;
        public const int TYPE_LOGIN = 1;
        public const int TYPE_JOIN = 2;

        #region member field
        private Socket _server;
        private string _ip; // server IP
        private int _port; // server port
        private byte[] _packetData;
        private int _packetIdx;

        private string _id;
        private string _password;

        private Thread _workingThread;
        private bool _isStart;
        private bool _isAlive;
        #endregion

        #region 소켓 연결/해제
        // Socket 연결
        public void start(string ip, int port, string id, string password, int type) {
            if (!_isStart) {
                _isStart = true;
                _isAlive = true;

                _ip = ip;
                _port = port;
                _id = id;
                _password = password;
                _type = type;
                _packetData = new byte[MAX_SIZE];
                _packetIdx = 0;

                connectToServer();
            } else {
                Console.WriteLine("이미 접속중");
            }
        }

        // Socket 연결 해제
        public void stop() {
            if (_isStart) {
                _isStart = false;
                _isAlive = false;

                if (_server != null) {
                    _server.Close();
                    _server = null;
                }
                if (_workingThread != null) {
                    _workingThread.Interrupt();
                    _workingThread = null;
                }
                Console.WriteLine("++ 서버와의 연결이 종료 되었습니다.");
            }
        }
        #endregion

        #region 비동기 소켓 함수
        // server로 접속
        private void connectToServer() {
            Socket connect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connect.BeginConnect(new IPEndPoint(IPAddress.Parse(_ip), _port), new AsyncCallback(connectedEvent_Server), connect);
        }

        // server로 접속 성공시 발생 이벤트
        private void connectedEvent_Server(IAsyncResult iar) {
            try {
                Socket callBack = (Socket) iar.AsyncState;
                callBack.EndConnect(iar);
                _server = callBack;
                Console.WriteLine("++ 서버로 접속 하였습니다. [ " + _ip + ":" + _port + " ]");

                // 수신 대기
                receivePacket();

                // 유효 패킷 가공 Thread
                if (_workingThread == null) {
                    _workingThread = new Thread(new ThreadStart(workingThread));
                    _workingThread.Start();
                }

                switch (_type) {
                    case TYPE_LOGIN: // 계정 정보 전송
                        sendPacket(new C_Login(_id, _password));
                        Console.WriteLine("++ 로그인 정보 전송 완료 : " + _id + " / " + _password);
                        break;
                    case TYPE_JOIN: // 회원가입
                        sendPacket(new C_Join(_id, _password));
                        Console.WriteLine("++ 회원가입 전송 완료 : " + _id + " / " + _password);
                        break;
                }
            } catch (SocketException e) {
                if (e.ErrorCode == 10061) {
                    Console.WriteLine("++ SocketException : 서버가 닫혀 있습니다. [ " + _ip + ":" + _port + " ]");
                    showLoginResult("서버로 연결할 수 없습니다.");
                } else {
                    Console.WriteLine("ErrorCode : " + e.ErrorCode);
                    Console.WriteLine(e);
                }
                stop();
            } catch (Exception e) {
                Console.WriteLine(e);
                stop();
            }
        }

        // server의 패킷 수신
        private void receivePacket() {
            try {
                if (_server != null) {
                    byte[] data = new byte[MAX_SIZE];
                    _server.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(receiveResultEvent), data);
                }
            } catch (SocketException e) {
                if (e.ErrorCode == 10054 || e.ErrorCode == 10053) {
                    Console.WriteLine("++ SocketException : 서버가 종료 되었습니다. " + _ip + ":" + _port);
                } else {
                    Console.WriteLine("ErrorCode : " + e.ErrorCode);
                    Console.WriteLine(e);
                }
                stop();
            } catch (Exception e) {
                Console.WriteLine(e);
                stop();
            }
        }

        // server의 패킷 수신 성공시 발생 이벤트
        private void receiveResultEvent(IAsyncResult iar) {
            try {
                byte[] tempData = (byte[]) iar.AsyncState;
                if (_server != null) {
                    int size = _server.EndReceive(iar);
                    if (size != 0) {
                        Array.Copy(tempData, 0, _packetData, _packetIdx, size);
                        _packetIdx += size;
                    }
                }

                receivePacket();
            } catch (SocketException e) {
                if (e.ErrorCode == 10054 || e.ErrorCode == 10053) {
                    Console.WriteLine("++ SocketException : 서버가 종료 되었습니다. " + _ip + ":" + _port);
                } else {
                    Console.WriteLine("ErrorCode : " + e.ErrorCode);
                    Console.WriteLine(e);
                }
                stop();
            } catch (Exception e) {
                Console.WriteLine(e);
                stop();
            }
        }

        // server로 패킷 전송
        public void sendPacket(WritePacket packet) {
            try {
                byte[] data = packet.getPacketData();
                _server.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(sendResultEvent), _server);
            } catch (SocketException e) {
                if (e.ErrorCode == 10054 || e.ErrorCode == 10053) {
                    Console.WriteLine("++ SocketException : 서버가 종료 되었습니다. " + _ip + ":" + _port);
                } else {
                    Console.WriteLine("ErrorCode : " + e.ErrorCode);
                    Console.WriteLine(e);
                }
                stop();
            } catch (Exception e) {
                Console.WriteLine(e);
                stop();
            }
        }

        // server로 패킷 전송 성공시 발생 이벤트
        private void sendResultEvent(IAsyncResult iar) {
            try {
                Socket callBack = (Socket) iar.AsyncState;
                if (callBack == null || !callBack.Connected) {
                    stop();
                }
            } catch (SocketException e) {
                if (e.ErrorCode == 10054 || e.ErrorCode == 10053) {
                    Console.WriteLine("++ SocketException : 서버가 종료 되었습니다. " + _ip + ":" + _port);
                } else {
                    Console.WriteLine("ErrorCode : " + e.ErrorCode);
                    Console.WriteLine(e);
                }
                stop();
            } catch (Exception e) {
                Console.WriteLine(e);
                stop();
            }
        }
        #endregion

        #region 패킷 가공 Thread
        // 유효 패킷 가공 Thread
        private void workingThread() {
            try {
                while (_isAlive) {
                    if (_packetData != null) {
                        int size = getSize(_packetData);
                        if (size != 0 && size <= _packetIdx) {
                            byte[] data = new byte[size];
                            Array.Copy(_packetData, 0, data, 0, size);
                            Array.Copy(_packetData, size, _packetData, 0, _packetIdx - size);
                            _packetIdx -= size;
                            packetHandler(data);
                        }
                    }
                    Thread.Sleep(20);
                }
            } catch(ThreadInterruptedException) {
                Console.WriteLine("++ workingThread Interrupted");
            } catch (Exception e) {
                Console.WriteLine(e);
            } finally {
                stop();
                _workingThread = null;
                //System.Windows.Forms.Application.Exit();
            }
        }

        // 패킷 크기 반환
        private int getSize(byte[] data) {
            int size = data[0] & 0xff;
            size |= data[1] << 8 & 0xff00;
            return size;
        }
        #endregion

        #region 실제 Receive 패킷 처리
        // S -> C 패킷 처리
        private void packetHandler(byte[] data) {
            byte[] packet = new byte[data.Length - 2];
            Array.Copy(data, 2, packet, 0, data.Length - 2);

            int opcode = packet[0];
            switch (opcode) {
                case Opcodes.S_LOGIN_RESULT: // 로그인 결과
                    new S_LoginResult(this, packet);
                    break;
                case Opcodes.S_MYINFO: // 내정보
                    new S_MyInfo(this, packet);
                    break;
                case Opcodes.S_BUDDY: // 친구 관련
                    new S_Buddy(this, packet);
                    break;
                case Opcodes.S_MEMO: // 쪽지 관련
                    new S_Memo(this, packet);
                    break;
                case Opcodes.S_JOIN_RESULT: // 회원가입 결과
                    new S_JoinResult(this, packet);
                    break;
            }
        }
        #endregion

        #region event
        // 로그인 결과
        public delegate void loginResultDelegate(string result);
        public event loginResultDelegate loginResultEvent;
        public void showLoginResult(string result) {
            if (loginResultEvent != null) {
                loginResultEvent(result);
            }
        }

        // 회원가입 결과
        public delegate void joinResultDelegate(string result);
        public event joinResultDelegate joinResultEvent;
        public void showJoinResult(string result) {
            if (joinResultEvent != null) {
                joinResultEvent(result);
            }
        }

        // 내정보
        public delegate void myInfoDelegate(User user);
        public event myInfoDelegate myInfoEvent;
        public void setMyInfo(User user) {
            if (myInfoEvent != null) {
                myInfoEvent(user);
            }
        }

        // 친구 목록
        public delegate void buddyListDelegate(List<User> users);
        public event buddyListDelegate buddyListEvent;
        public void setBuddyList(List<User> users) {
            if (buddyListEvent != null) {
                buddyListEvent(users);
            }
        }

        // 친구 접속 알림
        public delegate void buddyLoginDelegate(bool isLogin, string id);
        public event buddyLoginDelegate buddyLoginEvent;
        public void showBuddyLogin(bool isLogin, string id) {
            if (buddyLoginEvent != null) {
                buddyLoginEvent(isLogin, id);
            }
        }

        // 친구 정보 변경
        public delegate void buddyInfoDelegate(User buddy);
        public event buddyInfoDelegate buddyInfoEvent;
        public void setBuddyInfo(User buddy) {
            if (buddyInfoEvent != null) {
                buddyInfoEvent(buddy);
            }
        }

        // 친구 검색 결과
        public delegate void searchResultDelegate(int type, User user);
        public event searchResultDelegate searchResultEvent;
        public void showSearchResult(int type, User user) {
            if (searchResultEvent != null) {
                searchResultEvent(type, user);
            }
        }

        // 친구 신청
        public delegate void buddyRequestDelegate(User user, string requestMsg);
        public event buddyRequestDelegate buddyRequestEvent;
        public void showBuddyRequest(User user, string requestMsg) {
            if (buddyRequestEvent != null) {
                buddyRequestEvent(user, requestMsg);
            }
        }

        // 그룹 목록
        public delegate void buddyGroupListDelegate(List<string> groupList);
        public event buddyGroupListDelegate buddyGroupListEvent;
        public void setBuddyGroupList(List<string> groupList) {
            if (buddyGroupListEvent != null) {
                buddyGroupListEvent(groupList);
            }
        }

        // 쪽지 수신
        public delegate void readMemoDelegate(Memo memo);
        public event readMemoDelegate readMemoEvent;
        public void showReadMemo(Memo memo) {
            if (readMemoEvent != null) {
                readMemoEvent(memo);
            }
        }

        // 수신 쪽지 목록
        public delegate void readMemoListDelegate(List<Memo> memoList);
        public event readMemoListDelegate readMemoListEvent;
        public void setReadListMemo(List<Memo> memoList) {
            if (readMemoListEvent != null) {
                readMemoListEvent(memoList);
            }
        }

        // 미확인 쪽지 갯수
        public delegate void notReadMemoCountDelegate(int count);
        public event notReadMemoCountDelegate notReadMemoCountEvent;
        public void setNotReadMemoCount(int count) {
            if (notReadMemoCountEvent != null) {
                notReadMemoCountEvent(count);
            }
        }
        #endregion

    }
}