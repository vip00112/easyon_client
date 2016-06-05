using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EasyOn {
    public partial class BuddyRequestForm : Form {

        private MainForm _main;
        private Point _currentPoint;
        private User _requestUser;

        public BuddyRequestForm(MainForm main, User user, string requestMsg, List<string> groupList) {
            InitializeComponent();
            Text = user.nickname + "님의 친구 신청";
            label1.Text = user.nickname + "님의 친구 신청";

            _main = main;
            _requestUser = user;

            byte[] data = user.profile;
            if (data != null) {
                using (MemoryStream ms = new MemoryStream(data)) {
                    Bitmap bmp = new Bitmap(ms);
                    profile.Image = bmp;
                }
            } else {
                profile.Image = Properties.Resources.profile;
            }
            nickname.Text = user.nickname;
            statusMsg.Text = user.statusMsg;
            addBuddyMsg.Text = requestMsg;
            foreach (string group in groupList) {
                addBuddyGroup.Items.Add(group);
            }
            addBuddyGroup.SelectedIndex = 0;
        }

        // form border paint
        private void form_BoderPaint(object sender, PaintEventArgs e) {
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen greenPen = new Pen(Color.FromArgb(0xff, 0x42, 0x42, 0x42), 1);
            e.Graphics.DrawRectangle(greenPen, 0, 0, width, height);
        }

        #region form move Events
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

        // 수락 버튼 클릭
        private void yesButton_Click(object sender, EventArgs e) {
            string groupName = addBuddyGroup.SelectedItem.ToString();
            _requestUser.groupName = groupName;
            _main.addBuddy(_requestUser);
            
            Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_RESPONE, true, _requestUser.no, groupName));
            Close();
        }

        // 거절 버튼 클릭
        private void noButton_Click(object sender, EventArgs e) {
            DialogResult dr = MessageBox.Show(_requestUser.nickname + "님의 친구 신청을 거절 하시겠습니까?", "EasyOn", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK) {
                Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_RESPONE, false, _requestUser.no, ""));
                Close();
            }
        }

        // x 버튼 클릭
        private void closeBtn_Click(object sender, EventArgs e) {
            Close();
        }

    }
}
