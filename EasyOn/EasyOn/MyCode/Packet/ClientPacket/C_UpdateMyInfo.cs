using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class C_UpdateMyInfo : SendPacket {

        public C_UpdateMyInfo(User user) {
            writeC(Opcodes.C_UPDATE_MYINFO);
            writeS(user.nickname);
            writeS(user.statusMsg);
            byte[] profile = user.profile;
            if (profile != null) {
                writeH(profile.Length);
                writeBytes(profile);
            } else {
                writeH(0);
            }
        }

    }
}
