using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_Chat : SendPacket {

        public const int TYPE_OPEN = 1; // 채팅창 생성
        public const int TYPE_LOG = 2; // 이전 대화 목록
        public const int TYPE_MSG = 3; // 메시지 전송

        public C_Chat(int type, Chat chat) {
            writeC(Opcodes.C_CHAT);
            writeH(type);

            switch (type) {
                case TYPE_OPEN: // 채팅창 생성
                    {
                        writeH(chat.memberList.Count);
                        foreach (User member in chat.memberList) {
                            writeD(member.no);
                        }
                    }
                    break;
            }
        }

        public C_Chat(int type, int chatNo) {
            writeC(Opcodes.C_CHAT);
            writeH(type);

            switch (type) {
                case TYPE_LOG: // 이전 대화 목록
                    {
                        writeD(chatNo);
                    }
                    break;
            }
        }

        public C_Chat(int type, int chatNo, string msg) {
            writeC(Opcodes.C_CHAT);
            writeH(type);

            switch (type) {
                case TYPE_MSG: // 메시지 전송
                    {
                        writeD(chatNo);
                        writeS(msg);
                    }
                    break;
            }
        }

    }
}
