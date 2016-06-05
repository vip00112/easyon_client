
namespace EasyOn {
    class Opcodes {
        // Client Opcode
        public const int C_LOGIN = 1; // 로그인 정보
        public const int C_BUDDY = 2; // 친구 관련
        public const int C_UPDATE_MYINFO = 3; // 내 정보 수정
        public const int C_UPDATE_GROUP = 4; // 그룹 정보 수정
        public const int C_MEMO = 5; // 쪽지 관련
        public const int C_JOIN = 6; // 회원 가입

        // Server Opcode
        public const int S_LOGIN_RESULT = 1; // 로그인 결과
        public const int S_MYINFO = 2; // 내정보
        public const int S_BUDDY = 3; // 친구 목록
        public const int S_MEMO = 4; // 쪽지 관련
        public const int S_JOIN_RESULT = 5; // 회원가입 결과
    }
}
