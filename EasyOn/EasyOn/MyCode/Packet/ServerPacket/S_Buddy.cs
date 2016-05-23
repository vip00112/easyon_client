using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class S_Buddy : ReadPacket {

        public const int TYPE_INFO = 1; // 내 정보 변경
        public const int TYPE_LIST = 2; // 친구 목록
        public const int TYPE_LOGIN = 3; // 내 로그인/로그아웃
        public const int TYPE_REQUEST = 4; // 친구 신청
        public const int TYPE_REQUEST_LIST = 5; // 친구 신청 목록
        public const int TYPE_SEARCH_RESULT = 6; // 친구 검색 결과
        public const int TYPE_GROUPS = 7; // 그룹 목록

        public S_Buddy(Worker worker, byte[] packet)
            : base(worker, packet) {

            int type = readH();

            switch (type) {
                case TYPE_INFO: // 내 정보 변경
                    {
                        int no = readD();
                        string id = readS();
                        string nickname = readS();
                        string statusMsg = readS();
                        int fileSize = readH();
                        byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;
                        bool online = readC() == 1 ? true : false;
                        worker.setBuddyInfo(new User(no, id, nickname, statusMsg, profile, online));
                    }
                    break;

                case TYPE_LIST: // 친구 목록
                    {
                        List<User> users = new List<User>();
                        int totalCount = readH();
                        for (int i = 0; i < totalCount; i++) {
                            int no = readD();
                            string id = readS();
                            string nickname = readS();
                            string statusMsg = readS();
                            int fileSize = readH();
                            byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;
                            bool online = readC() == 1 ? true : false;
                            string group = readS();
                            users.Add(new User(no, id, nickname, statusMsg, profile, online, group));
                        }
                        worker.setBuddyList(users);
                    }
                    break;

                case TYPE_LOGIN: // 내 로그인/로그아웃
                    {
                        bool isLogin = readC() == 1 ? true : false;
                        string id = readS();
                        worker.showBuddyLogin(isLogin, id);
                    }
                    break;

                case TYPE_REQUEST: // 친구 신청
                    {
                        int no = readD();
                        string id = readS();
                        string nickname = readS();
                        string statusMsg = readS();
                        int fileSize = readH();
                        byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;
                        string requestMsg = readS();
                        worker.showBuddyRequest(new User(no, id, nickname, statusMsg, profile, false, ""), requestMsg);
                    }
                    break;

                case TYPE_REQUEST_LIST: // 친구 신청 목록
                    {
                        List<User> users = new List<User>();
                        int totalCount = readH();
                        for (int i = 0; i < totalCount; i++) {
                            int no = readD();
                            string id = readS();
                            string nickname = readS();
                            string statusMsg = readS();
                            int fileSize = readH();
                            byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;
                            string requestMsg = readS();

                            worker.showBuddyRequest(new User(no, id, nickname, statusMsg, profile, false, ""), requestMsg);
                        }
                    }
                    break;
                case TYPE_SEARCH_RESULT: // 친구 검색 결과
                    {
                        int subType = readC(); // 1:결과 있음, 0:결과 없음
                        if (subType == 1) {
                            int no = readD();
                            string id = readS();
                            string nickname = readS();
                            string statusMsg = readS();
                            int fileSize = readH();
                            byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;

                            worker.showSearchResult(subType, new User(no, id, nickname, statusMsg, profile, false));
                        } else {
                            worker.showSearchResult(subType, null);
                        }
                    }
                    break;
                case TYPE_GROUPS: // 그룹 목록
                    {
                        List<string> groupList = new List<string>();
                        int totalCount = readH();
                        for (int i = 0; i < totalCount; i++) {
                            string group = readS();
                            groupList.Add(group);
                        }
                        worker.setBuddyGroupList(groupList);
                    }
                    break;
            }
        }
    }
}