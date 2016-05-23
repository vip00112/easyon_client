using System;
using System.Text;

namespace EasyOn {
    class ReadPacket {
        private byte[] _data;
        private int _offset;

        protected ReadPacket(Worker worker, byte[] packet) {
            _data = packet;
            _offset = 1;

            // ReadPacket ClassName 표기
            // Console.WriteLine(getClassName() + " : " + _data.Length);
        }

        protected int readC() {
            int result = 0;
            try {
                result = _data[_offset++] & 0xff;
            } catch (Exception e) {
                Console.WriteLine("[ Exception Class : " + getClassName() + " ] " + e);
            }
            return result;
        }

        protected int readH() {
            int result = 0;
            try {
                result = _data[_offset++] & 0xff;
                result |= _data[_offset++] << 8 & 0xff00;
            } catch (Exception e) {
                Console.WriteLine("[ Exception Class : " + getClassName() + " ] " + e);
            }
            return result;
        }

        protected int readD() {
            int result = 0;
            try {
                result = _data[_offset++] & 0xff;
                result |= _data[_offset++] << 8 & 0xff00;
                result |= _data[_offset++] << 16 & 0xff0000;
                result |= (int) (_data[_offset++] << 24 & 0xff000000);
            } catch (Exception e) {
                Console.WriteLine("[ Exception Class : " + getClassName() + " ] " + e);
            }
            return result;
        }

        public byte[] readBytes(int length) {
            byte[] result = new byte[length];
            try {
                Array.Copy(_data, _offset, result, 0, length);
                _offset += length;
            } catch (Exception e) {
                Console.WriteLine("[ Exception Class : " + getClassName() + " ] " + e);
            }
            return result;
        }

        protected string readS() {
            string result = "";
            try {
                int length = 0;
                int index = _offset;
                while (index < _data.Length && _data[index++] != 0) {
                    length++;
                }
                byte[] strBytes = new byte[length];
                Array.Copy(_data, _offset, strBytes, 0, length);
                result = Encoding.UTF8.GetString(strBytes);
                _offset += length + 1;
            } catch (Exception e) {
                Console.WriteLine("[ Exception Class : " + getClassName() + " ] "+ e);
            }
            return result;
        }

        protected byte[] readAllBytes() {
            byte[] result = new byte[_data.Length - _offset];
            try {
                Array.Copy(_data, _offset, result, 0, _data.Length - _offset);
                _offset = _data.Length;
            } catch (Exception e) {
                Console.WriteLine("[ Exception Class : " + getClassName() + " ] " + e);
            }
            return result;
        }

        private string getClassName() {
            return GetType().Name;
        }

    }
}
