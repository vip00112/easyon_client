using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace EasyOn {
    public partial class MainForm : Form {

        // TitleBar
        private bool _isPossibleMax = false; // 최대화 가능 여부
        private Point _currentPoint; // Form 이동 처리

        // MyBox
        private User _user;

        // 쪽지함 Form
        private MemoListForm _memoForm;

        #region Form
        // Form Create
        public MainForm() {
            InitializeComponent();
            Width = 395;

            _memoForm = new MemoListForm();
            setObjectListView(); // ObjectListView 설정
            setMenuPanel(); // 메뉴 설정
            setTooltip(); // tooltip

            // worker event 등록
            Worker.getInstance().myInfoEvent += new Worker.myInfoDelegate(setMyInfo);
            Worker.getInstance().buddyListEvent += new Worker.buddyListDelegate(setBuddyList);
            Worker.getInstance().buddyLoginEvent += new Worker.buddyLoginDelegate(showBuddyLogin);
            Worker.getInstance().buddyInfoEvent += new Worker.buddyInfoDelegate(setBuddyInfo);
            Worker.getInstance().searchResultEvent += new Worker.searchResultDelegate(showSearchResult);
            Worker.getInstance().buddyRequestEvent += new Worker.buddyRequestDelegate(showBuddyRequest);
            Worker.getInstance().buddyGroupListEvent += new Worker.buddyGroupListDelegate(setBuddyGroupList);
            Worker.getInstance().readMemoEvent += new Worker.readMemoDelegate(showReadMemo);
            Worker.getInstance().notReadMemoCountEvent += new Worker.notReadMemoCountDelegate(setNotReadMemoCount);

            titleButton_Max.Enabled = _isPossibleMax;
            new LoginForm().ShowDialog();
        }

        // form border paint
        private void form_BoderPaint(object sender, PaintEventArgs e) {
            int width = this.Width - 1;
            int height = this.Height - 1;
            Pen greenPen = new Pen(Color.FromArgb(0xff, 0x42, 0x42, 0x42), 1);
            e.Graphics.DrawRectangle(greenPen, 0, 0, width, height);
        }

        // Form Closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Worker.getInstance().stop();
        }

        // 메뉴 설정
        private void setMenuPanel() {
            menuPanel.Parent = this;
            menuPanel.Width = Width - 2;
            menuPanel.Height = Height - titleBar.Height - 2;
            menuPanel.Location = new Point(1, titleBar.Height + 1);
            menuPanel.BringToFront();
        }

        // tooltip
        private void setTooltip() {
            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 100;
            tooltip.ReshowDelay = 500;

            tooltip.SetToolTip(titleIcon, "메뉴");
            tooltip.SetToolTip(memoIcon, "쪽지함");
            tooltip.SetToolTip(profile, "프로필 사진 변경");
            tooltip.SetToolTip(nickname_Text, "닉네임 변경");
            tooltip.SetToolTip(statusMsg_Text, "상태 메시지 변경");
        }
        #endregion

        #region ObjectListView
        // ObjectListView 설정
        private void setObjectListView() {
            buddyList.AlwaysGroupByColumn = GroupColum; // GroupColum으로 그룹 고정
            buddyList.ShowGroups = true; // 그룹 표기
            buddyList.ShowItemCountOnGroups = true; // 그룹내 아이템 갯수 표기
            buddyList.GroupWithItemCountFormat = "{0} ({1})"; // 아이템 갯수 표기 포맷 : 기타 (4) : 복수 그룹
            buddyList.GroupWithItemCountSingularFormat = "{0} ({1})"; // 아이템 갯수 표기 포맷 : 기타 (4) : 1개 그룹
            buddyList.PrimarySortColumn = IdColum; // 고정 정렬 칼럼 지정
            buddyList.SortGroupItemsByPrimaryColumn = false; // 그룹화 후 위에서 지정한 칼럼기준 정렬
            buddyList.FormatRow += delegate (object sender, BrightIdeasSoftware.FormatRowEventArgs e) {
                if (e.Model is User) {
                    User buddy = (User) e.Model;
                    if (buddy.isOnline) {
                        e.Item.ForeColor = Color.Black;
                    }
                }
            };
        }

        // itemList 추가 : 친구 목록 설정
        private void addBuddyList(List<User> buddyList) {
            _user.buddyList = buddyList;
            this.buddyList.SetObjects(_user.buddyList);
        }

        // item 추가 : 친구 추가
        public void addBuddy(User buddy) {
            _user.buddyList.Add(buddy);
            buddyList.ClearObjects();
            buddyList.SetObjects(_user.buddyList);
        }

        // item 삭제 : 친구 삭제
        private void removeBuddy(int buddyNo) {
            User buddy = _user.buddyList.Find(user => user.no == buddyNo);
            if (buddy != null) {
                _user.buddyList.Remove(buddy);
                buddyList.ClearObjects();
                buddyList.SetObjects(_user.buddyList);
            }
        }

        // 친구 로그인/로그아웃 표기
        private void updateLogin(bool isLogin, string id) {
            User buddy = _user.buddyList.Find(user => user.id == id);
            if (buddy != null) {
                buddy.isOnline = isLogin;
                buddyList.UpdateObject(buddy);
            }
        }

        // 친구 정보 변경
        private void updateBuddyInfo(User buddyInfo) {
            User buddy = _user.buddyList.Find(user => user.no == buddyInfo.no);
            if (buddy != null) {
                buddy.nickname = buddyInfo.nickname;
                buddyInfo.statusMsg = buddyInfo.statusMsg;
                buddy.profile = buddyInfo.profile;
                buddyList.UpdateObject(buddy);
            }
        }

        // 친구 그룹 변경
        private void updateGroup(int buddyNo, string groupName) {
            User buddy = _user.buddyList.Find(user => user.no == buddyNo);
            if (buddy != null) {
                buddy.groupName = groupName;
                buddyList.UpdateObject(buddy);
            }
        }

        // listview item active event : 더블클릭/엔터 이벤트 -> 쪽지 보내기
        private void buddyList_ItemActivate(object sender, EventArgs e) {
           User buddy = buddyList.SelectedObject as User;
            if (buddy != null) {
                WriteForm wf = new WriteForm(_user, buddy);
                wf.Show();
            }
        }
        #endregion

        #region worker Events
        // 내정보
        private void setMyInfo(User user) {
            if (InvokeRequired) {
                this.Invoke(new Worker.myInfoDelegate(setMyInfo), user);
            } else {
                _user = user;
                nickname_Text.Text = user.nickname;
                statusMsg_Text.Text = user.statusMsg;
                _memoForm.setUser(user);

                // 프로필 이미지
                byte[] data = user.profile;
                if (data != null) {
                    using (MemoryStream ms = new MemoryStream(data)) {
                        Bitmap bmp = new Bitmap(ms);
                        profile.Image = bmp;
                    }
                }
            }
        }

        // 친구 목록
        private void setBuddyList(List<User> buddys) {
            if (InvokeRequired) {
                this.Invoke(new Worker.buddyListDelegate(setBuddyList), buddys);
            } else {
                addBuddyList(buddys);
            }
        }

        // 친구 로그인/로그아웃 알림
        private void showBuddyLogin(bool isLogin, string id) {
            if (InvokeRequired) {
                this.Invoke(new Worker.buddyLoginDelegate(showBuddyLogin), new object[] { isLogin, id });
            } else {
                updateLogin(isLogin, id);
            }
        }

        // 친구 정보 변경
        private void setBuddyInfo(User buddyInfo) {
            if (InvokeRequired) {
                this.Invoke(new Worker.buddyInfoDelegate(setBuddyInfo), buddyInfo);
            } else {
                updateBuddyInfo(buddyInfo);
            }
        }

        // 친구 검색 결과
        private void showSearchResult(int type, User user) {
            if (InvokeRequired) {
                this.Invoke(new Worker.searchResultDelegate(showSearchResult), new object[] { type, user });
            } else {
                if (type == 1) {
                    id_Search.Text = "검색 결과 : " + user.id;

                    if (user.profile == null) {
                        profile_Search.Image = Properties.Resources.profile;
                    } else {
                        byte[] data = user.profile;
                        if (data != null) {
                            using (MemoryStream ms = new MemoryStream(data)) {
                                Bitmap bmp = new Bitmap(ms);
                                profile_Search.Image = bmp;
                            }
                        }
                    }
                    no_Search.Text = user.no.ToString();
                    nickname_Search.Text = user.nickname;
                    statusMsg_Search.Text = user.statusMsg;
                    addBuddyButton.Enabled = true;
                } else if (type == 2) {
                    MessageBox.Show("검색 결과가 존재하지 않습니다,", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    id_SearchInput.Focus();
                    resetFindBuddy();
                    addBuddyButton.Enabled = false;
                }
            }
        }

        // 친구 신청
        private void showBuddyRequest(User user, string requestMsg) {
            if (InvokeRequired) {
                this.Invoke(new Worker.buddyRequestDelegate(showBuddyRequest), new object[] { user, requestMsg });
            } else {
                BuddyRequestForm bf = new BuddyRequestForm(this, user, requestMsg, _user.groupList);
                bf.Show();
            }
        }

        // 그룹 목록
        private void setBuddyGroupList(List<string> groupList) {
            if (InvokeRequired) {
                this.Invoke(new Worker.buddyGroupListDelegate(setBuddyGroupList), groupList);
            } else {
                _user.groupList = groupList;
            }
        }

        // 쪽지 수신
        private void showReadMemo(Memo memo) {
            if (InvokeRequired) {
                this.Invoke(new Worker.readMemoDelegate(showReadMemo), memo);
            } else {
                _memoForm.addMemo(memo);
                ReadForm rf = new ReadForm(_user, memo);
                rf.Show();
            }
        }

        // 미확인 쪽지 갯수
        private void setNotReadMemoCount(int count) {
            if (InvokeRequired) {
                this.Invoke(new Worker.notReadMemoCountDelegate(setNotReadMemoCount), count);
            } else {
                if (count > 0) {
                    newMemoLabel.Parent = memoIcon;
                    newMemoLabel.Location = new Point(memoIcon.Width - newMemoLabel.Width, 1);

                    newMemoLabel.Enabled = true;
                    newMemoLabel.Visible = true;
                } else {
                    newMemoLabel.Enabled = false;
                    newMemoLabel.Visible = false;
                }
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

        #region titleBar Events
        #region Form Move Events
        // mouse double click
        private void titleBar_DoubleClick(object sender, MouseEventArgs e) {
            if (_isPossibleMax) {
                if (titleButton_Max.Text == "□") {
                    titleButton_Max.Text = "▣";
                    WindowState = FormWindowState.Maximized;
                } else {
                    titleButton_Max.Text = "□";
                    WindowState = FormWindowState.Normal;
                }
                titleBar.Width = Width;
            }
        }

        // mouse down
        private void titleBar_Down(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _currentPoint = new Point(-e.X, -e.Y);
            }
        }

        // mouse move
        private void titleBar_Move(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Location = new Point(Location.X + (_currentPoint.X + e.X), Location.Y + (_currentPoint.Y + e.Y));
            }
        }
        #endregion

        // 메뉴 아이콘 show/hide
        private void visibleTitleIcon(bool isVisible) {
            if (isVisible) {
                titleIcon.BackColor = Color.White;
                menuPanel.Show();
                menuPanel.BringToFront();
            } else {
                menuPanel.Hide();
                titleIcon.BackColor = Color.FromArgb(221, 221, 221);
            }
        }

        // 메뉴 아이콘 클릭
        private void titleIcon_Click(object sender, EventArgs e) {
            if (menuPanel.Visible) {
                visibleTitleIcon(false);
            } else {
                resetFindBuddy();
                resetManagementBuddy();
                visibleTitleIcon(true);
            }
        }

        // 쪽지함 아이콘 클릭
        private void memoIcon_Click(object sender, EventArgs e) {
            if (_memoForm.Visible) {
                _memoForm.Hide();
            } else {
                _memoForm.resetMemoWriter();
                _memoForm.Show();
            }
        }

        // 최소화, 닫기 버튼 클릭
        private void titleBarButton_Click(object sender, EventArgs e) {
            if (sender == titleButton_Min) {
                WindowState = FormWindowState.Minimized;
            } else if (sender == titleButton_Max) {
                Button maxBtn = (sender as Button);
                if (maxBtn.Text == "□") {
                    maxBtn.Text = "▣";
                    WindowState = FormWindowState.Maximized;
                } else {
                    maxBtn.Text = "□";
                    WindowState = FormWindowState.Normal;
                }
                titleBar.Width = Width;
            } else if (sender == titleButton_Close) {
                Close();
            }
        }
        #endregion

        #region myBox Events
        // myBox click
        private void myBox_Click(object sender, EventArgs e) {
            profile.Focus();
        }

        // profile click
        private void profile_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Application.StartupPath;
            openFile.DefaultExt = "jpg";
            openFile.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFile.ShowDialog() == DialogResult.OK) {
                FileInfo fi = new FileInfo(openFile.FileName);
                byte[] data = new byte[fi.Length];
                using (FileStream fs = fi.OpenRead()) {
                    fs.Read(data, 0, data.Length);
                }
                changeProfile(data);
            }
        }

        // nickname_Text/statusMsg_Text click
        private void myText_Click(object sender, EventArgs e) {
            (sender as TextBox).ReadOnly = false;
            if (sender == nickname_Text) {
                nickname.Text = "Enter키 입력시 변경 완료";
            } else if (sender == statusMsg_Text) {
                statusMsg.Text = "Enter키 입력시 변경 완료";
            }
        }

        // nickname_Text/statusMsg_Text focus out
        private void myText_FocutOut(object sender, EventArgs e) {
            (sender as TextBox).ReadOnly = true;
            if (sender == nickname_Text) {
                changeNickname();
            } else if (sender == statusMsg_Text) {
                changeStatusMsg();
            }
            profile.Focus();
        }

        // nickname_Text/statusMsg_Text key down
        private void myText_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                (sender as TextBox).ReadOnly = true;
                if (sender == nickname_Text) {
                    changeNickname();
                } else if (sender == statusMsg_Text) {
                    changeStatusMsg();
                }
                profile.Focus();
            }
        }

        // 프로필 사진 변경
        private void changeProfile(byte[] data) {
            if (_user.profile == null || !_user.profile.SequenceEqual(data)) {
                _user.profile = data;
                Worker.getInstance().sendPacket(new C_UpdateMyInfo(_user));
                using (MemoryStream ms = new MemoryStream(data)) {
                    Bitmap bmp = new Bitmap(ms);
                    profile.Image = bmp;
                }
                MessageBox.Show("프로필 사진이 변경 되었습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        // 대화명 변경
        private void changeNickname() {
            if (_user.nickname != nickname_Text.Text) {
                _user.nickname = nickname_Text.Text;
                Worker.getInstance().sendPacket(new C_UpdateMyInfo(_user));
                MessageBox.Show("대화명이 변경 되었습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            nickname.Text = "대화명";
        }

        // 상태 메시지 변경
        private void changeStatusMsg() {
            if (_user.statusMsg != statusMsg_Text.Text) {
                _user.statusMsg = statusMsg_Text.Text;
                Worker.getInstance().sendPacket(new C_UpdateMyInfo(_user));
                MessageBox.Show("상태 메시지가 변경 되었습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            statusMsg.Text = "상태 메시지";
        }
        #endregion

        #region menu Events
        // 친구 찾기 탭 초기화
        private void resetFindBuddy() {
            id_SearchInput.Text = "";
            id_Search.Text = "검색 결과 : ";
            profile_Search.Image = null;
            nickname_Search.Text = "";
            statusMsg_Search.Text = "";
            addBuddyMsg.Text = "안녕하세요. 친구 신청 합니다.";
            addBuddyGroup.Items.Clear();
            foreach (string group in _user.groupList) {
                addBuddyGroup.Items.Add(group);
            }
            addBuddyGroup.SelectedIndex = 0;
        }

        // 친구 관리 탭 초기화
        private void resetManagementBuddy() {
            // 기존 목록 삭제
            tabPage2.Controls.Clear();

            int x = 6;
            int y = 6;
            int width = 367;
            int height = 23;
            foreach (User user in _user.buddyList) {
                Panel panel = new Panel();
                panel.Size = new Size(width, height);
                panel.Location = new Point(x, y);
                tabPage2.Controls.Add(panel);

                Label label = new Label();
                label.Text = user.id + " (" + user.nickname + ")";
                label.Location = new Point(1, 5);
                label.AutoSize = true;
                panel.Controls.Add(label);

                ComboBox combo = new ComboBox();
                combo.Tag = user.no;
                combo.Size = new Size(130, 20);
                combo.Location = new Point(164, 2);
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (string group in _user.groupList) {
                    combo.Items.Add(group);
                }
                for (int i = 0; i < combo.Items.Count; i++) {
                    if (combo.Items[i].ToString() == user.groupName) {
                        combo.SelectedIndex = i;
                        break;
                    }
                }
                combo.SelectedIndexChanged += new EventHandler(changeGroup);
                panel.Controls.Add(combo);

                Button btn = new Button();
                btn.Tag = new object[] { user.no, user.id + " (" + user.nickname + ")" };
                btn.TabStop = false;
                btn.Location = new Point(300, 0);
                btn.Size = new Size(41, 23);
                btn.Text = "삭제";
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(221, 221, 221);
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 66, 66);
                btn.FlatStyle = FlatStyle.Flat;
                btn.ForeColor = Color.FromArgb(66, 66, 66);
                btn.Click += new EventHandler(deleteBuddy);
                btn.MouseEnter += new EventHandler(flatButton_MouseEnter);
                btn.MouseLeave += new EventHandler(flatButton_MouseLeave);
                panel.Controls.Add(btn);

                y += height + 5;
            }
        }

        // 그룹 관리 탭 초기화
        private void resetManagementGroup() {
            // 기존 목록 삭제
            groupList.Controls.Clear();
            addGroupText.Text = "";
            addGroupText.Focus();

            int y = 3;
            int height = 21;
            foreach (string group in _user.groupList) {
                TextBox txt = new TextBox();
                txt.Name = "groupTxt_" + group;
                txt.Size = new Size(227, height);
                txt.Location = new Point(3, y);
                txt.ReadOnly = true;
                txt.TabStop = false;
                txt.Text = group;
                groupList.Controls.Add(txt);

                Button okBtn = new Button();
                okBtn.Name = "groupOkBtn_" + group;
                okBtn.Visible = false;
                okBtn.Tag = group;
                okBtn.TabStop = false;
                okBtn.Location = new Point(236, y);
                okBtn.Size = new Size(50, height);
                okBtn.Text = "완료";
                okBtn.Cursor = Cursors.Hand;
                okBtn.FlatAppearance.BorderColor = Color.White;
                okBtn.FlatAppearance.BorderSize = 0;
                okBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(221, 221, 221);
                okBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 66, 66);
                okBtn.FlatStyle = FlatStyle.Flat;
                okBtn.ForeColor = Color.FromArgb(66, 66, 66);
                okBtn.Click += new EventHandler(okGroupButton_Click);
                okBtn.MouseEnter += new EventHandler(flatButton_MouseEnter);
                okBtn.MouseLeave += new EventHandler(flatButton_MouseLeave);
                groupList.Controls.Add(okBtn);

                Button updateBtn = new Button();
                updateBtn.Name = "groupUpdateBtn_" + group;
                updateBtn.Tag = group;
                updateBtn.TabStop = false;
                updateBtn.Location = new Point(236, y);
                updateBtn.Size = new Size(50, height);
                updateBtn.Text = "수정";
                updateBtn.Cursor = Cursors.Hand;
                updateBtn.FlatAppearance.BorderColor = Color.White;
                updateBtn.FlatAppearance.BorderSize = 0;
                updateBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(221, 221, 221);
                updateBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 66, 66);
                updateBtn.FlatStyle = FlatStyle.Flat;
                updateBtn.ForeColor = Color.FromArgb(66, 66, 66);
                updateBtn.Click += new EventHandler(updateGroupButton_Click);
                updateBtn.MouseEnter += new EventHandler(flatButton_MouseEnter);
                updateBtn.MouseLeave += new EventHandler(flatButton_MouseLeave);
                groupList.Controls.Add(updateBtn);

                Button deleteBtn = new Button();
                deleteBtn.Name = "groupDeleteBtn_" + group;
                deleteBtn.Tag = group;
                deleteBtn.TabStop = false;
                deleteBtn.Location = new Point(292, y);
                deleteBtn.Size = new Size(50, height);
                deleteBtn.Text = "삭제";
                deleteBtn.Cursor = Cursors.Hand;
                deleteBtn.FlatAppearance.BorderColor = Color.White;
                deleteBtn.FlatAppearance.BorderSize = 0;
                deleteBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(221, 221, 221);
                deleteBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(66, 66, 66);
                deleteBtn.FlatStyle = FlatStyle.Flat;
                deleteBtn.ForeColor = Color.FromArgb(66, 66, 66);
                deleteBtn.Click += new EventHandler(deleteGroupButton_Click);
                deleteBtn.MouseEnter += new EventHandler(flatButton_MouseEnter);
                deleteBtn.MouseLeave += new EventHandler(flatButton_MouseLeave);
                groupList.Controls.Add(deleteBtn);

                // 기본 그룹 변경 불가
                if (group == "기타") {
                    okBtn.Visible = false;
                    updateBtn.Visible = false;
                    deleteBtn.Visible = false;
                }

                y += height + 5;
            }
        }

        // 친구 그룹 변경
        private void changeGroup(object sender, EventArgs e) {
            ComboBox combo = (ComboBox) sender;
            int buddyNo = (int) combo.Tag;
            string groupName = combo.SelectedItem.ToString();
            Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_CHANGE_GROUP, buddyNo, groupName));

            updateGroup(buddyNo, groupName);
        }

        // 친구 삭제 버튼
        private void deleteBuddy(object sender, EventArgs e) {
            Button btn = (Button) sender;
            object[] datas = (object[]) btn.Tag;
            DialogResult dr = MessageBox.Show(datas[1] + "님을 정말 삭제 하시겠습니까?", "EasyOn", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK) {
                int buddyNo = (int) datas[0];
                Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_REMOVE, buddyNo));

                removeBuddy(buddyNo);
                resetManagementBuddy();
            }
        }

        // tab 변경 이벤트
        private void menuTab_SelectedIndexChanged(object sender, EventArgs e) {
            if (menuTab.SelectedTab == tabPage1) { // 친구 찾기
                resetFindBuddy();
            } else if (menuTab.SelectedTab == tabPage2) { // 친구 관리
                resetManagementBuddy();
            } else if (menuTab.SelectedTab == tabPage3) { // 그룹 관리
                resetManagementGroup();
            }
        }

        // 친구 검색 버튼 클릭
        private void searchBuddyButton_Click(object sender, EventArgs e) {
            string id = id_SearchInput.Text;
            if (id.Trim() == "") {
                MessageBox.Show("검색할 아이디를 입력 해주세요.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (id == _user.id) {
                MessageBox.Show("자기 자신을 검색할 수 없습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_SEARCH, id));
        }

        // 친구 신청 버튼 클릭
        private void addBuddyButton_Click(object sender, EventArgs e) {
            if (id_Search.Text.Replace("검색 결과 : ", "") == "") {
                MessageBox.Show("검색 결과가 없습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int buddyNo = int.Parse(no_Search.Text);
            string groupName = addBuddyGroup.SelectedItem.ToString();

            // 이미 추가된 친구인지 확인
            foreach (User buddy in _user.buddyList) {
                if (buddy.no == buddyNo) {
                    MessageBox.Show("이미 등록된 친구 입니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 친구 view 추가
            User user = new User(buddyNo, id_Search.Text.Replace("검색 결과 : ", ""), nickname_Search.Text, statusMsg_Search.Text, null, false, groupName);
            addBuddy(user);
            
            Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_ADD, buddyNo, groupName, addBuddyMsg.Text));
            MessageBox.Show(id_Search.Text + "님을 " + groupName + " 그룹에 추가 하였습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        // 그룹 추가 버튼 클릭
        private void addGroupButton_Click(object sender, EventArgs e) {
            string groupName = addGroupText.Text;
            if (groupName.Trim() == "") {
                MessageBox.Show("그룹명을 입력 해주시기 바랍니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (groupName.Contains("(") || groupName.Contains(")")) {
                MessageBox.Show("그룹명에 '(', ')'는 포함될 수 없습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (_user.groupList.Contains(groupName)) {
                MessageBox.Show("이미 존재하는 그룹명 입니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.groupList.Add(groupName);
            Worker.getInstance().sendPacket(new C_UpdateGroup(_user));
            resetManagementGroup();
        }

        // 그룹 수정 완료 버튼 클릭
        private void okGroupButton_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            string name = (string) button.Tag;
            TextBox txt = groupList.Controls.Find("groupTxt_" + name, false).FirstOrDefault() as TextBox;
            Button updateBtn = groupList.Controls.Find("groupUpdateBtn_" + name, false).FirstOrDefault() as Button;
            Button deleteBtn = groupList.Controls.Find("groupDeleteBtn_" + name, false).FirstOrDefault() as Button;

            string groupName = txt.Text;
            if (name != groupName) {
                if (groupName.Trim() == "") {
                    MessageBox.Show("그룹명을 입력 해주시기 바랍니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (groupName.Contains("(") || groupName.Contains(")")) {
                    MessageBox.Show("그룹명에 '(', ')'는 포함될 수 없습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (_user.groupList.Contains(groupName)) {
                    MessageBox.Show("이미 존재하는 그룹명 입니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _user.groupList.Remove(name);
                _user.groupList.Add(groupName);
                foreach (User buddy in _user.buddyList) {
                    if (buddy.groupName == name) {
                        updateGroup(buddy.no, groupName);
                        Worker.getInstance().sendPacket(new C_Buddy(C_Buddy.TYPE_CHANGE_GROUP, buddy.no, groupName));
                    }
                }
                Worker.getInstance().sendPacket(new C_UpdateGroup(_user));
            }

            button.Tag = groupName;
            updateBtn.Tag = groupName;
            deleteBtn.Tag = groupName;

            txt.Name = "groupTxt_" + groupName;
            button.Name = "groupOkBtn_" + groupName;
            updateBtn.Name = "groupUpdateBtn_" + groupName;
            deleteBtn.Name = "groupDeleteBtn_" + groupName;

            button.Visible = false;
            txt.ReadOnly = true;
            updateBtn.Visible = true;
            deleteBtn.Visible = true;
        }

        // 그룹 수정 버튼 클릭
        private void updateGroupButton_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            string name = (string) button.Tag;
            TextBox txt = groupList.Controls.Find("groupTxt_" + name, false).FirstOrDefault() as TextBox;
            Button okBtn = groupList.Controls.Find("groupOkBtn_" + name, false).FirstOrDefault() as Button;
            Button deleteBtn = groupList.Controls.Find("groupDeleteBtn_" + name, false).FirstOrDefault() as Button;

            button.Visible = false;
            txt.ReadOnly = false;
            txt.Focus();
            okBtn.Visible = true;
            deleteBtn.Visible = false;
        }

        // 그룹 삭제 버튼 클릭
        private void deleteGroupButton_Click(object sender, EventArgs e) {
            string name = (string) (sender as Button).Tag;
            DialogResult dr = MessageBox.Show(name + " 그룹을 정말 삭제 하시겠습니까?", "EasyOn", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK) {
                foreach (User buddy in _user.buddyList) {
                    if (buddy.groupName == name) {
                        MessageBox.Show("친구가 존재하는 그룹은 삭제할 수 없습니다.", "EasyOn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                _user.groupList.Remove(name);
                resetManagementGroup();
                Worker.getInstance().sendPacket(new C_UpdateGroup(_user));
            }
        }
        #endregion

    }
}
