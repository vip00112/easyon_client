using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyOn {
    public partial class WriteForm : Form {

        private Point _currentPoint;
        private User _user;
        private User _buddy;

        public WriteForm(User user, User buddy) {
            InitializeComponent();

            _user = user;
            _buddy = buddy;

            target.Text = _buddy.nickname + " (" + _buddy.id + ")";
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

        // esc 키 감지
        private void esc_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void sendButton_Click(object sender, EventArgs e) {
            string msg = writeMsg.Text;
            if (msg.Trim() == "") {
                MessageBox.Show("내용을 입력 하세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (msg.Length > 3000) {
                MessageBox.Show("최대 3,000자 까지만 가능 합니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Worker.getInstance().sendPacket(new C_Memo(C_Memo.TYPE_MSG, _buddy.no, msg));
            Close();
        }

    }
}
