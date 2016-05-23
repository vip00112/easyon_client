﻿
namespace EasyOn {
    class Opcodes {
        // Client Opcode
        public const int C_LOGIN = 1; // 로그인 정보
        public const int C_BUDDY = 2; // 친구 관련
        public const int C_UPDATE_MYINFO = 3; // 내 정보 수정
        public const int C_UPDATE_GROUP = 4; // 그룹 정보 수정
        public const int C_CHAT = 5; // 채팅 관련

        // Server Opcode
        public const int S_LOGIN_RESULT = 1; // 로그인 결과
        public const int S_MYINFO = 2; // 내정보
        public const int S_BUDDY = 3; // 친구 목록
        public const int S_CHAT = 4; // 채팅 관련
    }
}
