using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class S_Chat : ReadPacket {

        private const int TYPE_LIST = 1; // 채팅 목록
        private const int TYPE_LOG = 2; // 이전 대화 목록
        private const int TYPE_ADD = 3; // 새로운 채팅

        public S_Chat(Worker worker, byte[] packet)
            : base(worker, packet) {

            int type = readH();

            switch (type) {
                case TYPE_LIST: // 채팅 목록
                    {
                        List<Chat> chatList = new List<Chat>();
                        int totalCount = readH();
                        for (int i = 0; i < totalCount; i++) {
                            int chatNo = readD();
                            DateTime regdate = CommonUtil.javaTimeStampToDateTime(readD());

                            Chat chat = new Chat(chatNo, regdate);

                            // 채팅 참가 유저 목록
                            List<User> memberList = new List<User>();
                            int memberCount = readH();
                            for (int j = 0; j < memberCount; j++) {
                                int userNo = readD();
                                string id = readS();
                                string nickname = readS();
                                string statusMsg = readS();
                                int fileSize = readH();
                                byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;

                                memberList.Add(new User(userNo, id, nickname, statusMsg, profile, false));
                            }
                            chat.memberList = memberList;
                            chatList.Add(chat);
                        }
                        worker.setChatList(chatList);
                    }
                    break;

                case TYPE_LOG: // 이전 대화 목록
                    {
                        int logNo = readD();
                        int chatNo = readD();
                        int userNo = readD();
                        string nickname = readS();
                        string msg = readS();
                        DateTime regdate = CommonUtil.javaTimeStampToDateTime(readD());
                        worker.addChatLog(new ChatLog(logNo, chatNo, userNo, nickname, msg, regdate));
                    }
                    break;

                case TYPE_ADD: // 새로운 채팅
                    {
                        int chatNo = readD();
                        DateTime regdate = CommonUtil.javaTimeStampToDateTime(readD());

                        Chat chat = new Chat(chatNo, regdate);

                        // 채팅 참가 유저 목록
                        List<User> memberList = new List<User>();
                        int memberCount = readH();
                        for (int j = 0; j < memberCount; j++) {
                            int userNo = readD();
                            string id = readS();
                            string nickname = readS();
                            string statusMsg = readS();
                            int fileSize = readH();
                            byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;

                            memberList.Add(new User(userNo, id, nickname, statusMsg, profile, false));
                        }
                        chat.memberList = memberList;
                        worker.addChat(chat);
                    }
                    break;
            }

        }

    }
}