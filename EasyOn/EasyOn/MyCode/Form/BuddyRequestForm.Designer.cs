namespace EasyOn {
    partial class BuddyRequestForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuddyRequestForm));
            this.statusMsg = new System.Windows.Forms.TextBox();
            this.profile = new System.Windows.Forms.PictureBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addBuddyMsg = new System.Windows.Forms.RichTextBox();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.addBuddyGroup = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profile)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusMsg
            // 
            this.statusMsg.BackColor = System.Drawing.Color.White;
            this.statusMsg.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusMsg.Location = new System.Drawing.Point(120, 105);
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.ReadOnly = true;
            this.statusMsg.Size = new System.Drawing.Size(266, 21);
            this.statusMsg.TabIndex = 3;
            this.statusMsg.TabStop = false;
            // 
            // profile
            // 
            this.profile.BackColor = System.Drawing.Color.White;
            this.profile.Location = new System.Drawing.Point(12, 36);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(100, 100);
            this.profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profile.TabIndex = 7;
            this.profile.TabStop = false;
            // 
            // nickname
            // 
            this.nickname.BackColor = System.Drawing.Color.White;
            this.nickname.Cursor = System.Windows.Forms.Cursors.Default;
            this.nickname.Location = new System.Drawing.Point(120, 61);
            this.nickname.Name = "nickname";
            this.nickname.ReadOnly = true;
            this.nickname.Size = new System.Drawing.Size(266, 21);
            this.nickname.TabIndex = 4;
            this.nickname.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(118, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "상태 메시지";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(118, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "대화명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "신청 메시지";
            // 
            // addBuddyMsg
            // 
            this.addBuddyMsg.BackColor = System.Drawing.Color.White;
            this.addBuddyMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addBuddyMsg.Location = new System.Drawing.Point(12, 168);
            this.addBuddyMsg.Name = "addBuddyMsg";
            this.addBuddyMsg.ReadOnly = true;
            this.addBuddyMsg.Size = new System.Drawing.Size(374, 96);
            this.addBuddyMsg.TabIndex = 8;
            this.addBuddyMsg.Text = "안녕하세요. 친구 신청 합니다.";
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.yesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.yesButton.FlatAppearance.BorderSize = 0;
            this.yesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.yesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.yesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.yesButton.Location = new System.Drawing.Point(311, 292);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 10;
            this.yesButton.Text = "수락";
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            this.yesButton.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.yesButton.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.noButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.noButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.noButton.FlatAppearance.BorderSize = 0;
            this.noButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.noButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.noButton.Location = new System.Drawing.Point(230, 292);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 11;
            this.noButton.Text = "거절";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            this.noButton.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.noButton.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // addBuddyGroup
            // 
            this.addBuddyGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addBuddyGroup.FormattingEnabled = true;
            this.addBuddyGroup.Location = new System.Drawing.Point(12, 266);
            this.addBuddyGroup.Name = "addBuddyGroup";
            this.addBuddyGroup.Size = new System.Drawing.Size(374, 20);
            this.addBuddyGroup.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 30);
            this.panel1.TabIndex = 13;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("SansSerif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.closeBtn.Location = new System.Drawing.Point(367, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(30, 30);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.TabStop = false;
            this.closeBtn.Text = "×";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "님의 친구 신청";
            // 
            // BuddyRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 331);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addBuddyGroup);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addBuddyMsg);
            this.Controls.Add(this.statusMsg);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuddyRequestForm";
            this.Text = "BuddyRequestForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.form_BoderPaint);
            ((System.ComponentModel.ISupportInitialize)(this.profile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox statusMsg;
        private System.Windows.Forms.PictureBox profile;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox addBuddyMsg;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.ComboBox addBuddyGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label1;
    }
}