using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_Memo : WritePacket {

        public const int TYPE_MSG = 1; // 쪽지 전송
        public const int TYPE_LIST = 2; // 수신 쪽지 목록
        public const int TYPE_READ = 3; // 수신 쪽지 읽음

        public C_Memo(int type, int buddyNo, string msg) {
            writeC(Opcodes.C_MEMO);
            writeH(type);

            switch (type) {
                case TYPE_MSG: // 쪽지 전송
                    {
                        writeD(buddyNo); // 대상 유저 번호
                        writeS(msg);
                    }
                    break;
            }
        }

        public C_Memo(int type, int no) {
            writeC(Opcodes.C_MEMO);
            writeH(type);

            switch (type) {
                case TYPE_LIST: // 수신 쪽지 목록
                    {
                        writeD(no); // 보낸 유저 번호 writerNo
                    }
                    break;
                case TYPE_READ: // 수신 쪽지 읽음
                    {
                        writeD(no); // 쪽지 번호 no
                    }
                    break;
            }
        }

    }
}
