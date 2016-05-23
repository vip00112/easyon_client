using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyOn {
    public partial class ChatForm : Form {

        private Point _currentPoint;
        private Chat _chat;
        private User _user;
        private int _chatCount;
        private int _lastLocY;

        public ChatForm(User user, Chat chat) {
            InitializeComponent();

            _user = user;
            _chat = chat;
            foreach (User member in chat.memberList) {
                titleLabel.Text = member.nickname + " ";
                Text = member.nickname + " ";
            }

            // Worker Event 등록
            Worker.getInstance().chatLogEvent += new Worker.chatLogDelegate(addChatLog);

            // 이전 대화 불러오기
            Worker.getInstance().sendPacket(new C_Chat(C_Chat.TYPE_LOG, chat.no));
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

        #region worker Event
        // 이전 대화 목록
        private void addChatLog(ChatLog log) {
            if (InvokeRequired) {
                this.Invoke(new Worker.chatLogDelegate(addChatLog), log);
            } else {
                createChatControl(log);
            }
        }
        #endregion

        // 전송 버튼 클릭
        private void sendButton_Click(object sender, EventArgs e) {
            sendMsg(messageBox.Text);
        }

        // 메시지 입력 박스 엔터 키 감지
        private void messageBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (e.Modifiers != Keys.Control) {
                    sendMsg(messageBox.Text);
                    e.SuppressKeyPress = true;
                }
            }
        }

        // 메시지 전송
        private void sendMsg(string msg) {
            if (msg.Trim() == "") {
                messageBox.Focus();
                return;
            } else if (msg.Length > 21839) {
                MessageBox.Show("전송 하려는 내용은 20,000글자를 넘을 수 없습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                messageBox.Focus();
                return;
            }
            messageBox.Text = "";

            ChatLog log = new ChatLog(_chat.no, _user.no, _user.nickname, msg, DateTime.Now);
            createChatControl(log);

            Worker.getInstance().sendPacket(new C_Chat(C_Chat.TYPE_MSG, _chat.no, msg));
        }

        // 대화내역 Control 생성
        private void createChatControl(ChatLog log) {
            int locY = _lastLocY - chatList.VerticalScroll.Value;

            Label nickname = new Label();
            nickname.Location = new Point(1, locY + 5);
            nickname.Text = log.nickname;
            nickname.ForeColor = Color.Black;
            nickname.AutoSize = true;

            Label time = new Label();
            time.Location = new Point(279, locY + 5);
            time.Text = log.regdate.ToString("MM/dd HH:mm:ss");
            time.ForeColor = Color.FromArgb(180, 180, 180);
            time.AutoSize = true;

            Label message = new Label();
            message.Location = new Point(3, locY + 20);
            message.Text = log.msg;
            message.BackColor = Color.FromArgb(240, 240, 240);
            message.MaximumSize = new Size(359, int.MaxValue);
            message.Padding = new Padding(5);
            message.AutoSize = true;

            chatList.Controls.Add(nickname);
            chatList.Controls.Add(time);
            chatList.Controls.Add(message);
            if (chatList.VerticalScroll.Visible) {
                message.Focus();
                messageBox.Focus();
            }

            _lastLocY += 20 + message.Height + 10;
            _chatCount++;
        }
    }
}
