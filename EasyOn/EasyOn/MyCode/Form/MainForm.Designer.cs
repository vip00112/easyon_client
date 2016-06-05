namespace EasyOn {
    partial class MainForm {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.titleBar = new System.Windows.Forms.Panel();
            this.newMemoLabel = new System.Windows.Forms.Label();
            this.memoIcon = new System.Windows.Forms.PictureBox();
            this.titleButton_Min = new System.Windows.Forms.Button();
            this.titleButton_Max = new System.Windows.Forms.Button();
            this.titleButton_Close = new System.Windows.Forms.Button();
            this.titleIcon = new System.Windows.Forms.PictureBox();
            this.myBox = new System.Windows.Forms.Panel();
            this.statusMsg_Text = new System.Windows.Forms.TextBox();
            this.nickname_Text = new System.Windows.Forms.TextBox();
            this.statusMsg = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.Label();
            this.profile = new System.Windows.Forms.PictureBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.no_Search = new System.Windows.Forms.Label();
            this.addBuddyGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addBuddyMsg = new System.Windows.Forms.RichTextBox();
            this.id_Search = new System.Windows.Forms.Label();
            this.statusMsg_Search = new System.Windows.Forms.TextBox();
            this.profile_Search = new System.Windows.Forms.PictureBox();
            this.nickname_Search = new System.Windows.Forms.TextBox();
            this.addBuddyButton = new System.Windows.Forms.Button();
            this.searchBuddyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id_SearchInput = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupList = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.addGroupText = new System.Windows.Forms.TextBox();
            this.buddyList = new BrightIdeasSoftware.ObjectListView();
            this.GroupColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IdColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NicknameColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.StatusMsgColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleIcon)).BeginInit();
            this.myBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.menuTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile_Search)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buddyList)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.titleBar.Controls.Add(this.newMemoLabel);
            this.titleBar.Controls.Add(this.memoIcon);
            this.titleBar.Controls.Add(this.titleButton_Min);
            this.titleBar.Controls.Add(this.titleButton_Max);
            this.titleBar.Controls.Add(this.titleButton_Close);
            this.titleBar.Controls.Add(this.titleIcon);
            this.titleBar.Location = new System.Drawing.Point(1, 1);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(393, 30);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.titleBar_DoubleClick);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_Down);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_Move);
            // 
            // newMemoLabel
            // 
            this.newMemoLabel.AutoSize = true;
            this.newMemoLabel.BackColor = System.Drawing.Color.Transparent;
            this.newMemoLabel.Enabled = false;
            this.newMemoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.newMemoLabel.ForeColor = System.Drawing.Color.Red;
            this.newMemoLabel.Location = new System.Drawing.Point(52, 0);
            this.newMemoLabel.Name = "newMemoLabel";
            this.newMemoLabel.Size = new System.Drawing.Size(12, 9);
            this.newMemoLabel.TabIndex = 2;
            this.newMemoLabel.Text = "N";
            this.newMemoLabel.Visible = false;
            this.newMemoLabel.Click += new System.EventHandler(this.memoIcon_Click);
            // 
            // memoIcon
            // 
            this.memoIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.memoIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.memoIcon.Image = global::EasyOn.Properties.Resources.memo;
            this.memoIcon.Location = new System.Drawing.Point(32, 0);
            this.memoIcon.Name = "memoIcon";
            this.memoIcon.Size = new System.Drawing.Size(32, 30);
            this.memoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.memoIcon.TabIndex = 1;
            this.memoIcon.TabStop = false;
            this.memoIcon.Click += new System.EventHandler(this.memoIcon_Click);
            // 
            // titleButton_Min
            // 
            this.titleButton_Min.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleButton_Min.Dock = System.Windows.Forms.DockStyle.Right;
            this.titleButton_Min.FlatAppearance.BorderSize = 0;
            this.titleButton_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.titleButton_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.titleButton_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleButton_Min.Font = new System.Drawing.Font("SansSerif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleButton_Min.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.titleButton_Min.Location = new System.Drawing.Point(303, 0);
            this.titleButton_Min.Name = "titleButton_Min";
            this.titleButton_Min.Size = new System.Drawing.Size(30, 30);
            this.titleButton_Min.TabIndex = 0;
            this.titleButton_Min.TabStop = false;
            this.titleButton_Min.Text = "_";
            this.titleButton_Min.UseVisualStyleBackColor = true;
            this.titleButton_Min.Click += new System.EventHandler(this.titleBarButton_Click);
            this.titleButton_Min.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.titleButton_Min.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // titleButton_Max
            // 
            this.titleButton_Max.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleButton_Max.Dock = System.Windows.Forms.DockStyle.Right;
            this.titleButton_Max.FlatAppearance.BorderSize = 0;
            this.titleButton_Max.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.titleButton_Max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.titleButton_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleButton_Max.Font = new System.Drawing.Font("SansSerif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleButton_Max.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.titleButton_Max.Location = new System.Drawing.Point(333, 0);
            this.titleButton_Max.Name = "titleButton_Max";
            this.titleButton_Max.Size = new System.Drawing.Size(30, 30);
            this.titleButton_Max.TabIndex = 0;
            this.titleButton_Max.TabStop = false;
            this.titleButton_Max.Text = "□";
            this.titleButton_Max.UseVisualStyleBackColor = true;
            this.titleButton_Max.Click += new System.EventHandler(this.titleBarButton_Click);
            this.titleButton_Max.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.titleButton_Max.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // titleButton_Close
            // 
            this.titleButton_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleButton_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.titleButton_Close.FlatAppearance.BorderSize = 0;
            this.titleButton_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.titleButton_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.titleButton_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.titleButton_Close.Font = new System.Drawing.Font("SansSerif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleButton_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.titleButton_Close.Location = new System.Drawing.Point(363, 0);
            this.titleButton_Close.Name = "titleButton_Close";
            this.titleButton_Close.Size = new System.Drawing.Size(30, 30);
            this.titleButton_Close.TabIndex = 0;
            this.titleButton_Close.TabStop = false;
            this.titleButton_Close.Text = "×";
            this.titleButton_Close.UseVisualStyleBackColor = true;
            this.titleButton_Close.Click += new System.EventHandler(this.titleBarButton_Click);
            this.titleButton_Close.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.titleButton_Close.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // titleIcon
            // 
            this.titleIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.titleIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleIcon.Image = ((System.Drawing.Image)(resources.GetObject("titleIcon.Image")));
            this.titleIcon.Location = new System.Drawing.Point(0, 0);
            this.titleIcon.Name = "titleIcon";
            this.titleIcon.Size = new System.Drawing.Size(32, 30);
            this.titleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.titleIcon.TabIndex = 0;
            this.titleIcon.TabStop = false;
            this.titleIcon.Click += new System.EventHandler(this.titleIcon_Click);
            // 
            // myBox
            // 
            this.myBox.BackColor = System.Drawing.Color.White;
            this.myBox.Controls.Add(this.statusMsg_Text);
            this.myBox.Controls.Add(this.nickname_Text);
            this.myBox.Controls.Add(this.statusMsg);
            this.myBox.Controls.Add(this.nickname);
            this.myBox.Controls.Add(this.profile);
            this.myBox.Location = new System.Drawing.Point(1, 31);
            this.myBox.Name = "myBox";
            this.myBox.Size = new System.Drawing.Size(393, 100);
            this.myBox.TabIndex = 1;
            this.myBox.Click += new System.EventHandler(this.myBox_Click);
            // 
            // statusMsg_Text
            // 
            this.statusMsg_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statusMsg_Text.Location = new System.Drawing.Point(108, 67);
            this.statusMsg_Text.Name = "statusMsg_Text";
            this.statusMsg_Text.ReadOnly = true;
            this.statusMsg_Text.Size = new System.Drawing.Size(276, 21);
            this.statusMsg_Text.TabIndex = 0;
            this.statusMsg_Text.TabStop = false;
            this.statusMsg_Text.Click += new System.EventHandler(this.myText_Click);
            this.statusMsg_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myText_KeyDown);
            this.statusMsg_Text.Leave += new System.EventHandler(this.myText_FocutOut);
            // 
            // nickname_Text
            // 
            this.nickname_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nickname_Text.Location = new System.Drawing.Point(108, 23);
            this.nickname_Text.Name = "nickname_Text";
            this.nickname_Text.ReadOnly = true;
            this.nickname_Text.Size = new System.Drawing.Size(276, 21);
            this.nickname_Text.TabIndex = 0;
            this.nickname_Text.TabStop = false;
            this.nickname_Text.Click += new System.EventHandler(this.myText_Click);
            this.nickname_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myText_KeyDown);
            this.nickname_Text.Leave += new System.EventHandler(this.myText_FocutOut);
            // 
            // statusMsg
            // 
            this.statusMsg.AutoSize = true;
            this.statusMsg.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusMsg.Location = new System.Drawing.Point(106, 52);
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Size = new System.Drawing.Size(69, 12);
            this.statusMsg.TabIndex = 0;
            this.statusMsg.Text = "상태 메시지";
            // 
            // nickname
            // 
            this.nickname.AutoSize = true;
            this.nickname.Cursor = System.Windows.Forms.Cursors.Default;
            this.nickname.Location = new System.Drawing.Point(106, 8);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(41, 12);
            this.nickname.TabIndex = 0;
            this.nickname.Text = "대화명";
            // 
            // profile
            // 
            this.profile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profile.Dock = System.Windows.Forms.DockStyle.Left;
            this.profile.ErrorImage = global::EasyOn.Properties.Resources.profile;
            this.profile.Image = global::EasyOn.Properties.Resources.profile;
            this.profile.InitialImage = global::EasyOn.Properties.Resources.profile;
            this.profile.Location = new System.Drawing.Point(0, 0);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(100, 100);
            this.profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profile.TabIndex = 0;
            this.profile.TabStop = false;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.menuTab);
            this.menuPanel.Location = new System.Drawing.Point(400, 31);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(393, 577);
            this.menuPanel.TabIndex = 0;
            this.menuPanel.Visible = false;
            // 
            // menuTab
            // 
            this.menuTab.Controls.Add(this.tabPage1);
            this.menuTab.Controls.Add(this.tabPage2);
            this.menuTab.Controls.Add(this.tabPage3);
            this.menuTab.Location = new System.Drawing.Point(3, 3);
            this.menuTab.Name = "menuTab";
            this.menuTab.SelectedIndex = 0;
            this.menuTab.Size = new System.Drawing.Size(387, 571);
            this.menuTab.TabIndex = 2;
            this.menuTab.SelectedIndexChanged += new System.EventHandler(this.menuTab_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.no_Search);
            this.tabPage1.Controls.Add(this.addBuddyGroup);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.addBuddyMsg);
            this.tabPage1.Controls.Add(this.id_Search);
            this.tabPage1.Controls.Add(this.statusMsg_Search);
            this.tabPage1.Controls.Add(this.profile_Search);
            this.tabPage1.Controls.Add(this.nickname_Search);
            this.tabPage1.Controls.Add(this.addBuddyButton);
            this.tabPage1.Controls.Add(this.searchBuddyButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.id_SearchInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(379, 545);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "친구 찾기";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // no_Search
            // 
            this.no_Search.AutoSize = true;
            this.no_Search.Enabled = false;
            this.no_Search.Location = new System.Drawing.Point(4, 95);
            this.no_Search.Name = "no_Search";
            this.no_Search.Size = new System.Drawing.Size(65, 12);
            this.no_Search.TabIndex = 6;
            this.no_Search.Text = "no_Search";
            this.no_Search.Visible = false;
            // 
            // addBuddyGroup
            // 
            this.addBuddyGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addBuddyGroup.FormattingEnabled = true;
            this.addBuddyGroup.Location = new System.Drawing.Point(6, 355);
            this.addBuddyGroup.Name = "addBuddyGroup";
            this.addBuddyGroup.Size = new System.Drawing.Size(367, 20);
            this.addBuddyGroup.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "신청 메시지";
            // 
            // addBuddyMsg
            // 
            this.addBuddyMsg.Location = new System.Drawing.Point(6, 253);
            this.addBuddyMsg.Name = "addBuddyMsg";
            this.addBuddyMsg.Size = new System.Drawing.Size(367, 96);
            this.addBuddyMsg.TabIndex = 2;
            this.addBuddyMsg.Text = "안녕하세요. 친구 신청 합니다.";
            // 
            // id_Search
            // 
            this.id_Search.AutoSize = true;
            this.id_Search.Location = new System.Drawing.Point(6, 107);
            this.id_Search.Name = "id_Search";
            this.id_Search.Size = new System.Drawing.Size(69, 12);
            this.id_Search.TabIndex = 3;
            this.id_Search.Text = "검색 결과 : ";
            // 
            // statusMsg_Search
            // 
            this.statusMsg_Search.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusMsg_Search.Location = new System.Drawing.Point(114, 191);
            this.statusMsg_Search.Name = "statusMsg_Search";
            this.statusMsg_Search.ReadOnly = true;
            this.statusMsg_Search.Size = new System.Drawing.Size(259, 21);
            this.statusMsg_Search.TabIndex = 0;
            this.statusMsg_Search.TabStop = false;
            // 
            // profile_Search
            // 
            this.profile_Search.Location = new System.Drawing.Point(6, 122);
            this.profile_Search.Name = "profile_Search";
            this.profile_Search.Size = new System.Drawing.Size(100, 100);
            this.profile_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profile_Search.TabIndex = 2;
            this.profile_Search.TabStop = false;
            // 
            // nickname_Search
            // 
            this.nickname_Search.Cursor = System.Windows.Forms.Cursors.Default;
            this.nickname_Search.Location = new System.Drawing.Point(114, 147);
            this.nickname_Search.Name = "nickname_Search";
            this.nickname_Search.ReadOnly = true;
            this.nickname_Search.Size = new System.Drawing.Size(259, 21);
            this.nickname_Search.TabIndex = 0;
            this.nickname_Search.TabStop = false;
            // 
            // addBuddyButton
            // 
            this.addBuddyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.addBuddyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBuddyButton.Enabled = false;
            this.addBuddyButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addBuddyButton.FlatAppearance.BorderSize = 0;
            this.addBuddyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.addBuddyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.addBuddyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBuddyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.addBuddyButton.Location = new System.Drawing.Point(6, 381);
            this.addBuddyButton.Name = "addBuddyButton";
            this.addBuddyButton.Size = new System.Drawing.Size(367, 42);
            this.addBuddyButton.TabIndex = 4;
            this.addBuddyButton.Text = "친구 신청";
            this.addBuddyButton.UseVisualStyleBackColor = false;
            this.addBuddyButton.Click += new System.EventHandler(this.addBuddyButton_Click);
            this.addBuddyButton.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.addBuddyButton.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // searchBuddyButton
            // 
            this.searchBuddyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.searchBuddyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBuddyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.searchBuddyButton.FlatAppearance.BorderSize = 0;
            this.searchBuddyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.searchBuddyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.searchBuddyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBuddyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.searchBuddyButton.Location = new System.Drawing.Point(298, 40);
            this.searchBuddyButton.Name = "searchBuddyButton";
            this.searchBuddyButton.Size = new System.Drawing.Size(75, 23);
            this.searchBuddyButton.TabIndex = 1;
            this.searchBuddyButton.Text = "검색";
            this.searchBuddyButton.UseVisualStyleBackColor = false;
            this.searchBuddyButton.Click += new System.EventHandler(this.searchBuddyButton_Click);
            this.searchBuddyButton.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.searchBuddyButton.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(112, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "상태 메시지";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "아이디로 친구 찾기";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(112, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "대화명";
            // 
            // id_SearchInput
            // 
            this.id_SearchInput.Location = new System.Drawing.Point(6, 42);
            this.id_SearchInput.Name = "id_SearchInput";
            this.id_SearchInput.Size = new System.Drawing.Size(286, 21);
            this.id_SearchInput.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(379, 545);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "친구 관리";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 23);
            this.panel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(164, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "삭제";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "test1 (dddddd)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupList);
            this.tabPage3.Controls.Add(this.addGroupButton);
            this.tabPage3.Controls.Add(this.addGroupText);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(379, 545);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "그룹 관리";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupList
            // 
            this.groupList.AutoScroll = true;
            this.groupList.Controls.Add(this.button4);
            this.groupList.Controls.Add(this.textBox1);
            this.groupList.Controls.Add(this.button3);
            this.groupList.Controls.Add(this.button2);
            this.groupList.Location = new System.Drawing.Point(6, 33);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(367, 506);
            this.groupList.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button4.Location = new System.Drawing.Point(180, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 21);
            this.button4.TabIndex = 2;
            this.button4.Text = "완료";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.addGroupButton_Click);
            this.button4.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.button4.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 21);
            this.textBox1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button3.Location = new System.Drawing.Point(236, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 21);
            this.button3.TabIndex = 2;
            this.button3.Text = "수정";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.addGroupButton_Click);
            this.button3.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button2.Location = new System.Drawing.Point(292, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.addGroupButton_Click);
            this.button2.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // addGroupButton
            // 
            this.addGroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.addGroupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addGroupButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.addGroupButton.FlatAppearance.BorderSize = 0;
            this.addGroupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.addGroupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.addGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addGroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.addGroupButton.Location = new System.Drawing.Point(298, 6);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(75, 23);
            this.addGroupButton.TabIndex = 2;
            this.addGroupButton.TabStop = false;
            this.addGroupButton.Text = "그룹 추가";
            this.addGroupButton.UseVisualStyleBackColor = false;
            this.addGroupButton.Click += new System.EventHandler(this.addGroupButton_Click);
            this.addGroupButton.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.addGroupButton.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // addGroupText
            // 
            this.addGroupText.Location = new System.Drawing.Point(6, 6);
            this.addGroupText.Name = "addGroupText";
            this.addGroupText.Size = new System.Drawing.Size(286, 21);
            this.addGroupText.TabIndex = 0;
            this.addGroupText.TabStop = false;
            // 
            // buddyList
            // 
            this.buddyList.AllColumns.Add(this.GroupColum);
            this.buddyList.AllColumns.Add(this.IdColum);
            this.buddyList.AllColumns.Add(this.NicknameColum);
            this.buddyList.AllColumns.Add(this.StatusMsgColum);
            this.buddyList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buddyList.CellEditUseWholeCell = false;
            this.buddyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupColum,
            this.IdColum,
            this.NicknameColum,
            this.StatusMsgColum});
            this.buddyList.Cursor = System.Windows.Forms.Cursors.Default;
            this.buddyList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.buddyList.FullRowSelect = true;
            this.buddyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.buddyList.HideSelection = false;
            this.buddyList.Location = new System.Drawing.Point(1, 140);
            this.buddyList.MultiSelect = false;
            this.buddyList.Name = "buddyList";
            this.buddyList.Size = new System.Drawing.Size(393, 469);
            this.buddyList.TabIndex = 0;
            this.buddyList.TabStop = false;
            this.buddyList.UseCompatibleStateImageBehavior = false;
            this.buddyList.View = System.Windows.Forms.View.Details;
            this.buddyList.ItemActivate += new System.EventHandler(this.buddyList_ItemActivate);
            // 
            // GroupColum
            // 
            this.GroupColum.AspectName = "groupName";
            this.GroupColum.Hideable = false;
            this.GroupColum.Text = "그룹";
            this.GroupColum.Width = 0;
            // 
            // IdColum
            // 
            this.IdColum.AspectName = "id";
            this.IdColum.Text = "ID";
            this.IdColum.Width = 78;
            // 
            // NicknameColum
            // 
            this.NicknameColum.AspectName = "nickname";
            this.NicknameColum.Text = "닉네임";
            this.NicknameColum.Width = 89;
            // 
            // StatusMsgColum
            // 
            this.StatusMsgColum.AspectName = "statusMsg";
            this.StatusMsgColum.Text = "상태 메시지";
            this.StatusMsgColum.Width = 200;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 612);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.buddyList);
            this.Controls.Add(this.myBox);
            this.Controls.Add(this.titleBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyOn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.form_BoderPaint);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleIcon)).EndInit();
            this.myBox.ResumeLayout(false);
            this.myBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.menuTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile_Search)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupList.ResumeLayout(false);
            this.groupList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buddyList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button titleButton_Close;
        private System.Windows.Forms.PictureBox titleIcon;
        private System.Windows.Forms.Button titleButton_Min;
        private System.Windows.Forms.Button titleButton_Max;
        private System.Windows.Forms.Panel myBox;
        private System.Windows.Forms.PictureBox profile;
        private System.Windows.Forms.TextBox statusMsg_Text;
        private System.Windows.Forms.TextBox nickname_Text;
        private System.Windows.Forms.Label statusMsg;
        private System.Windows.Forms.Label nickname;
        private System.Windows.Forms.Panel menuPanel;
        private BrightIdeasSoftware.ObjectListView buddyList;
        private BrightIdeasSoftware.OLVColumn IdColum;
        private BrightIdeasSoftware.OLVColumn NicknameColum;
        private BrightIdeasSoftware.OLVColumn StatusMsgColum;
        private BrightIdeasSoftware.OLVColumn GroupColum;
        private System.Windows.Forms.TabControl menuTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button searchBuddyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_SearchInput;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox statusMsg_Search;
        private System.Windows.Forms.PictureBox profile_Search;
        private System.Windows.Forms.TextBox nickname_Search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label id_Search;
        private System.Windows.Forms.ComboBox addBuddyGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox addBuddyMsg;
        private System.Windows.Forms.Button addBuddyButton;
        private System.Windows.Forms.Label no_Search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel groupList;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.TextBox addGroupText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox memoIcon;
        private System.Windows.Forms.Label newMemoLabel;
    }
}

