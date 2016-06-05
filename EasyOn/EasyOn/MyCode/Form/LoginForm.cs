using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyOn {
    public partial class LoginForm : Form {

        private Point _currentPoint; // Form 이동 처리

        public LoginForm() {
            InitializeComponent();

            // worker event 등록
            Worker.getInstance().loginResultEvent += new Worker.loginResultDelegate(showLoginResult);
            Worker.getInstance().joinResultEvent += new Worker.joinResultDelegate(showJoinResult);
        }

        // form border paint
        private void form_BoderPaint(object sender, PaintEventArgs e) {
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen greenPen = new Pen(Color.FromArgb(0xff, 0x42, 0x42, 0x42), 1);
            e.Graphics.DrawRectangle(greenPen, 0, 0, width, height);
        }

        #region worker event
        // 로그인 결과
        private void showLoginResult(string result) {
            if (InvokeRequired) {
                this.Invoke(new Worker.loginResultDelegate(showLoginResult), result);
            } else {
                if (result == "성공") {
                    Close();
                } else {
                    MessageBox.Show(result, "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    controlEnable(true);
                    Worker.getInstance().stop();
                    id.Focus();
                    id.SelectAll();
                }
            }
        }

        // 회원가입 결과
        private void showJoinResult(string result) {
            if (InvokeRequired) {
                this.Invoke(new Worker.joinResultDelegate(showJoinResult), result);
            } else {
                if (result == "성공") {
                    MessageBox.Show("회원 가입에 성공 하였습니다. 로그인 해주세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                } else {
                    MessageBox.Show(result, "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                controlEnable(true);
                Worker.getInstance().stop();
                id.Focus();
                id.SelectAll();
            }
        }
        #endregion

        #region Form Move Events
        // mouse down
        private void mouse_Down(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _currentPoint = new Point(-e.X, -e.Y);
            }
        }

        // mouse move
        private void mouse_Move(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (_currentPoint.X + e.X), Location.Y + (_currentPoint.Y + e.Y));
            }
        }
        #endregion

        #region Button Events
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

        // 로그인 클릭
        private void loginBtn_Click(object sender, EventArgs e) {
            if (id.Text.Trim() == "") {
                MessageBox.Show("올바른 아이디를 입력 해주세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (password.Text.Trim() == "") {
                MessageBox.Show("올바른 비밀번호를 입력 해주세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            controlEnable(false);
            Worker.getInstance().start("127.0.0.1", 2000, id.Text, password.Text, Worker.TYPE_LOGIN);
            password.Text = "";
        }

        // 회원가입 클릭
        private void joinBtn_Click(object sender, EventArgs e) {
            if (id.Text.Trim() == "") {
                MessageBox.Show("올바른 아이디를 입력 해주세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (password.Text.Trim() == "") {
                MessageBox.Show("올바른 비밀번호를 입력 해주세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            controlEnable(false);
            Worker.getInstance().start("127.0.0.1", 2000, id.Text, password.Text, Worker.TYPE_JOIN);
            password.Text = "";
        }

        // x 버튼 클릭
        private void closeBtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void minBtn_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        // control enable
        private void controlEnable(bool flag) {
            id.Enabled = flag;
            password.Enabled = flag;
            loginBtn.Enabled = flag;
            joinBtn.Enabled = flag;
        }

    }
}
