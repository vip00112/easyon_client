using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_Login : WritePacket {

        public C_Login(string id, string password) {
            writeC(Opcodes.C_LOGIN);
            writeS(id);
            writeS(password);
        }

    }
}
