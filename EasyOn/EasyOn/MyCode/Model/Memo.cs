using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    public class Memo {

        public int no {
            get; set;
        }

        public int writerNo {
            get; set;
        }

        public int readerNo {
            get; set;
        }

        public string writerId {
            get; set;
        }

        public string writerNickname {
            get; set;
        }

        public string msg {
            get; set;
        }

        public bool isRead {
            get; set;
        }

        public DateTime regdate {
            get; set;
        }

        public Memo(int no, int writerNo, string writerId, string writerNickname, int readerNo, string msg, bool isRead, DateTime regdate) {
            this.no = no;
            this.writerNo = writerNo;
            this.writerId = writerId;
            this.writerNickname = writerNickname;
            this.readerNo = readerNo;
            this.msg = msg;
            this.isRead = isRead;
            this.regdate = regdate;
        }
    }
}
