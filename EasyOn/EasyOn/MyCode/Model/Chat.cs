using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    public class Chat {
        // 채팅 번호
        public int no {
            get; set;
        }

        // 채팅 생성일
        public DateTime regdate {
            get; set;
        }

        // 채팅 참가 유저 목록
        public List<User> memberList {
            get; set;
        }

        public Chat(DateTime regdate) {
            this.regdate = regdate;
        }

        public Chat(int no, DateTime regdate) {
            this.no = no;
            this.regdate = regdate;
        }

        public bool isJoinedUser(int memberNo) {
            foreach (User member in memberList) {
                if (member.no == memberNo) {
                    return true;
                }
            }
            return false;
        }
    }
}
