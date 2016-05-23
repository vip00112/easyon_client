using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    public class ChatLog {
        // 로그 번호
        public int logNo {
            get; set;
        }

        // 채팅 번호
        public int chatNo {
            get; set;
        }

        // 유저 번호
        public int userNo {
            get; set;
        }

        // 유저 닉네임
        public string nickname {
            get; set;
        }

        // 메시지
        public string msg {
            get; set;
        }

        // 등록일
        public DateTime regdate {
            get; set;
        }

        public ChatLog(int chatNo, int userNo, string nickname, string msg, DateTime regdate) {
            this.chatNo = chatNo;
            this.userNo = userNo;
            this.nickname = nickname;
            this.msg = msg;
            this.regdate = regdate;
        }

        public ChatLog(int logNo, int chatNo, int userNo, string nickname, string msg, DateTime regdate) {
            this.logNo = logNo;
            this.chatNo = chatNo;
            this.userNo = userNo;
            this.nickname = nickname;
            this.msg = msg;
            this.regdate = regdate;
        }
    }
}
