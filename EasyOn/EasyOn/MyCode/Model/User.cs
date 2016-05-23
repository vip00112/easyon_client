using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    public class User {
        // 회원번호
        public int no {
            get; set;
        }

        // 아이디
        public string id {
            get; set;
        }

        // 비밀번호
        public string password {
            get; set;
        }

        // 닉네임
        public string nickname {
            get; set;
        }

        // 상태 메시지
        public string statusMsg {
            get; set;
        }

        // 프로필 사진
        public byte[] profile {
            get; set;
        }

        // 친구 목록
        public List<User> buddyList {
            get; set;
        }

        // 온라인 여부
        public bool isOnline {
            get; set;
        }

        // 그룹
        public string groupName {
            get; set;
        }

        // 그룹 목록
        public List<string> groupList {
            get; set;
        }

        // 채팅 목록
        public List<Chat> chatList {
            get; set;
        }

        public User(int no, string id, string password, string nickname, string statusMsg, byte[] profile) {
            this.no = no;
            this.id = id;
            this.password = password;
            this.nickname = nickname;
            this.statusMsg = statusMsg;
            this.profile = profile;
        }

        public User(int no, string id, string nickname, string statusMsg, byte[] profile, bool isOnline) {
            this.no = no;
            this.id = id;
            this.nickname = nickname;
            this.statusMsg = statusMsg;
            this.profile = profile;
            this.isOnline = isOnline;
        }

        public User(int no, string id, string nickname, string statusMsg, byte[] profile, bool isOnline, string groupName) {
            this.no = no;
            this.id = id;
            this.nickname = nickname;
            this.statusMsg = statusMsg;
            this.profile = profile;
            this.isOnline = isOnline;
            this.groupName = groupName;
        }
    }
}
