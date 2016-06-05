using System;
using System.Text;

namespace EasyOn {
    class WritePacket {
        private byte[] _data;
        private int _offset;

        protected WritePacket() {
            _data = new byte[1024 * 128];
            _offset = 0;
        }

        // 1byte write
        protected void writeC(int value) {
            _data[_offset++] = (byte) (value & 0xff);
        }

        // 2byte write
        protected void writeH(int value) {
            _data[_offset++] = (byte) (value & 0xff);
            _data[_offset++] = (byte) (value >> 8 & 0xff);
        }

        // 4byte write
        protected void writeD(int value) {
            _data[_offset++] = (byte) (value & 0xff);
            _data[_offset++] = (byte) (value >> 8 & 0xff);
            _data[_offset++] = (byte) (value >> 16 & 0xff);
            _data[_offset++] = (byte) (value >> 24 & 0xff);
        }

        // 문자열 write
        protected void writeS(string s) {
            byte[] data = Encoding.UTF8.GetBytes(s);
            foreach (byte b in data) {
                writeC(b);
            }
            writeC(0);
        }

        // byte[] write
        protected void writeBytes(byte[] bytes) {
            foreach (byte b in bytes) {
                writeC(b);
            }
        }

        // 길이값이 포함된 서버로 보낼 배열
        public byte[] getPacketData() {
            int length = _offset + 2;
            byte[] packet = new byte[length];
            packet[0] |= (byte) (length & 0xff);
            packet[1] |= (byte) (length >> 8 & 0xff);
            Array.Copy(_data, 0, packet, 2, _offset);
            return packet;
        }

    }
}
