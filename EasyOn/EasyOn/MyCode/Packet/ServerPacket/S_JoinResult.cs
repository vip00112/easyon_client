using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class S_JoinResult : ReadPacket {

        public const int TYPE_OK = 1; // 가입 성공
        public const int TYPE_USED = 2; // 이미 존재하는 아이디

        public S_JoinResult(Worker worker, byte[] packet)
			: base(worker, packet) {

            int result = readC();
            switch (result) {
                case TYPE_OK:
                    worker.showJoinResult("성공");
                    break;
                case TYPE_USED:
                    worker.showJoinResult("이미 사용중인 ID 입니다.");
                    break;
            }
        }

    }
}
