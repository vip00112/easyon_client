using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class S_MyInfo : ReadPacket {

        public S_MyInfo(Worker worker, byte[] packet)
            : base(worker, packet) {

            int no = readD();
            string id = readS();
            string password = readS();
            string nickname = readS();
            string statusMsg = readS();
            int fileSize = readH();
            byte[] profile = fileSize > 0 ? readBytes(fileSize) : null;
            worker.setMyInfo(new User(no, id, password, nickname, statusMsg, profile));
        }

    }
}
