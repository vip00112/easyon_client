using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyOn {
    public partial class MemoListForm : Form {

        private Point _currentPoint;
        private User _user;
        private List<Memo> _memoList;
        private int[] _userNos;

        public MemoListForm() {
            InitializeComponent();

            setObjectListView();

            Worker.getInstance().readMemoListEvent += new Worker.readMemoListDelegate(setReadListMemo);
        }

        private void MemoListForm_FormClosing(object sender, FormClosingEventArgs e) {
            Hide();
            e.Cancel = true;
        }

        public void setUser(User user) {
            _user = user;
        }

        #region form Events
        // form border paint
        private void form_BoderPaint(object sender, PaintEventArgs e) {
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen greenPen = new Pen(Color.FromArgb(0xff, 0x42, 0x42, 0x42), 1);
            e.Graphics.DrawRectangle(greenPen, 0, 0, width, height);
        }

        // mouse down
        private void form_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _currentPoint = new Point(-e.X, -e.Y);
            }
        }

        // mouse move
        private void form_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (_currentPoint.X + e.X), Location.Y + (_currentPoint.Y + e.Y));
            }
        }
        #endregion

        #region flat button Events
        // mouse enter
        private void flatButton_MouseEnter(object sender, EventArgs e) {
            (sender as Button).ForeColor = Color.FromArgb(0xFF, 0xFF, 0xFF);
        }

        // mouse leave
        private void flatButton_MouseLeave(object sender, EventArgs e) {
            if ((sender as Button).BackColor != Color.FromArgb(0x42, 0x42, 0x42)) {
                (sender as Button).ForeColor = Color.FromArgb(0x42, 0x42, 0x42);
            }
        }
        #endregion

        #region titleBar button Events
        private void minBtn_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            Close();
        }
        #endregion

        #region ObjectListView
        // ObjectListView 설정
        private void setObjectListView() {
            memoList.ShowGroups = false;
            memoList.PrimarySortColumn = regdateColum; // 고정 정렬 칼럼 지정
            memoList.PrimarySortOrder = SortOrder.Descending;
            memoList.FormatRow += delegate (object sender, BrightIdeasSoftware.FormatRowEventArgs e) {
                if (e.Model is Memo) {
                    Memo memo = (Memo) e.Model;
                    if (!memo.isRead) {
                        e.Item.BackColor = Color.LightGoldenrodYellow;
                    }
                }
            };
        }

        // itemList 설정 : 쪽지 목록 설정
        public void setMemoList(List<Memo> memoList) {
            _memoList = memoList;
            this.memoList.ClearObjects();
            this.memoList.SetObjects(_memoList);
        }

        // item 추가 : 쪽지 추가
        public void addMemo(Memo memo) {
            _memoList.Add(memo);
            memoList.ClearObjects();
            memoList.SetObjects(_memoList);
        }

        // listview item active event : 더블클릭/엔터 이벤트 -> 받은 쪽지 읽기
        private void memoList_ItemActivate(object sender, EventArgs e) {
            Memo memo = memoList.SelectedObject as Memo;
            if (memo != null) {
                if (!memo.isRead) { // 읽음 처리
                    memo.isRead = true;
                    Worker.getInstance().sendPacket(new C_Memo(C_Memo.TYPE_READ, memo.no));
                }

                ReadForm rf = new ReadForm(_user, memo);
                rf.Show();
            }
        }

        #endregion

        #region worker Events
        // 수신 쪽지 목록
        private void setReadListMemo(List<Memo> memoList) {
            if (InvokeRequired) {
                this.Invoke(new Worker.readMemoListDelegate(setReadListMemo), memoList);
            } else {
                setMemoList(memoList);
            }
        }
        #endregion

        // 쪽지 작성자 목록 초기화
        public void resetMemoWriter() {
            memoWriterComboBox.Items.Clear();
            memoWriterComboBox.Items.Add("전체 보기");

            int idx = 1;
            _userNos = new int[_user.buddyList.Count + 1];
            foreach (User writer in _user.buddyList) {
                memoWriterComboBox.Items.Add(writer.nickname + " (" + writer.id + ")");
                _userNos[idx++] = writer.no;
            }
            memoWriterComboBox.SelectedIndex = 0;
            memoWriterComboBox.Focus();
        }

        // 쪽지함 작성자 목록 변경
        private void memoWriterComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int writerNo = _userNos[memoWriterComboBox.SelectedIndex];
            Worker.getInstance().sendPacket(new C_Memo(C_Memo.TYPE_LIST, writerNo));
        }
    }
}
