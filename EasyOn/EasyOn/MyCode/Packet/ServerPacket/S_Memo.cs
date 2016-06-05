using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    class S_Memo : ReadPacket {

        private const int TYPE_MSG = 1; // 쪽지 수신
        private const int TYPE_LIST = 2; // 수신 쪽지 목록
        private const int TYPE_COUNT = 3; // 미확인 쪽지 갯수

        public S_Memo(Worker worker, byte[] packet)
			: base(worker, packet) {

            int type = readH();
            switch (type) {
                case TYPE_MSG: // 쪽지 수신
                    {
                        int no = readD();
                        int writerNo = readD();
                        string writerId = readS();
                        string writerNickname = readS();
                        int readerNo = readD();
                        string msg = readS();
                        bool isRead = readC() == 1 ? true : false;
                        DateTime regdate = CommonUtil.javaTimeStampToDateTime(readD());

                        Memo memo = new Memo(no, writerNo, writerId, writerNickname, readerNo, msg, isRead, regdate);
                        worker.showReadMemo(memo);
                    }
                    break;
                case TYPE_LIST: // 수신 쪽지 목록
                    {
                        List<Memo> memoList = new List<Memo>();
                        int totalCount = readH();
                        for (int i = 0; i < totalCount; i++) {
                            int no = readD();
                            int writerNo = readD();
                            string writerId = readS();
                            string writerNickname = readS();
                            int readerNo = readD();
                            string msg = readS();
                            bool isRead = readC() == 1 ? true : false;
                            DateTime regdate = CommonUtil.javaTimeStampToDateTime(readD());

                            memoList.Add(new Memo(no, writerNo, writerId, writerNickname, readerNo, msg, isRead, regdate));
                        }
                        worker.setReadListMemo(memoList);
                    }
                    break;
                case TYPE_COUNT: // 미확인 쪽지 갯수
                    {
                        int count = readH();
                        worker.setNotReadMemoCount(count);
                    }
                    break;
            }
        }

    }
}
