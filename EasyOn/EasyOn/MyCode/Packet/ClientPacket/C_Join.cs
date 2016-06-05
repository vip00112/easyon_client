using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_Join : WritePacket {

        public C_Join(string id, string password) {
            writeC(Opcodes.C_JOIN);
            writeS(id);
            writeS(password);
        }

    }
}
