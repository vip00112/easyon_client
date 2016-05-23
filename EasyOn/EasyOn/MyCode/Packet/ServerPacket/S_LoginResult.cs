using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class S_LoginResult : ReadPacket {

        public const int TYPE_OK = 1; // 로그인 성공
        public const int TYPE_WRONG = 2; // 잘못된 계정 정보
        public const int TYPE_USED = 3; // 이미 사용중

        public S_LoginResult(Worker worker, byte[] packet)
			: base(worker, packet) {

            int result = readC();
            switch (result) {
                case TYPE_OK:
                    worker.showLoginResult("성공");
                    break;
                case TYPE_WRONG:
                    worker.showLoginResult("아이디 또는 비밀번호가 올바르지 않습니다.");
                    break;
                case TYPE_USED:
                    worker.showLoginResult("이미 접속중인 계정 입니다.");
                    break;
            }
        }

    }
}
