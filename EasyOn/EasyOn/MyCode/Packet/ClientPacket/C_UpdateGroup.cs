using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_UpdateGroup : WritePacket {

        public C_UpdateGroup(User user) {
            writeC(Opcodes.C_UPDATE_GROUP);
            writeH(user.groupList.Count);
            foreach (string group in user.groupList) {
                writeS(group);
            }
        }

    }
}
