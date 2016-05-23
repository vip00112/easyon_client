using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_Buddy : SendPacket {

        public const int TYPE_ADD = 1; // 친구 추가
        public const int TYPE_REMOVE = 2; // 친구 삭제
        public const int TYPE_SEARCH = 3; // 친구 검색
        public const int TYPE_RESPONE = 4; // 친구 신청 답변
        public const int TYPE_CHANGE_GROUP = 5; // 친구 그룹 변경

        // 친구 추가
        public C_Buddy(int type, int buddyNo, string groupName, string requestMsg) {
            writeC(Opcodes.C_BUDDY);
            writeH(type);

            switch (type) {
                case TYPE_ADD: // 친구 추가
                    {
                        writeD(buddyNo);
                        writeS(groupName);
                        writeS(requestMsg);
                    }
                    break;

                case TYPE_REMOVE: // 친구 삭제
                    {

                    }
                    break;
            }
        }

        // 친구 삭제
        public C_Buddy(int type, int buddyNo) {
            writeC(Opcodes.C_BUDDY);
            writeH(type);

            switch (type) {
                case TYPE_REMOVE: // 친구 삭제
                    {
                        writeD(buddyNo);
                    }
                    break;
            }
        }

        // 친구 신청 답변
        public C_Buddy(int type, bool isYes, int buddyNo, string groupName) {
            writeC(Opcodes.C_BUDDY);
            writeH(type);

            switch (type) {
                case TYPE_RESPONE: // 친구 신청 답변
                    {
                        writeC(isYes ? 1 : 0);
                        writeD(buddyNo);
                        writeS(groupName);
                    }
                    break;
            }
        }

        // 친구 그룹 변경
        public C_Buddy(int type, int buddyNo, string groupName) {
            writeC(Opcodes.C_BUDDY);
            writeH(type);

            switch (type) {
                case TYPE_CHANGE_GROUP: // 친구 그룹 변경
                    {
                        writeD(buddyNo);
                        writeS(groupName);
                    }
                    break;
            }
        }

        // 친구 검색
        public C_Buddy(int type, string id) {
            writeC(Opcodes.C_BUDDY);
            writeH(type);

            switch (type) {

                case TYPE_SEARCH: // 친구 검색
                    {
                        writeS(id); // id
                    }
                    break;
            }
        }

    }
}