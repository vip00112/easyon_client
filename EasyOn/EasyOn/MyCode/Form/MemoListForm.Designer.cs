namespace EasyOn {
    partial class MemoListForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.minBtn = new System.Windows.Forms.Button();
            this.memoPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.memoList = new BrightIdeasSoftware.ObjectListView();
            this.writerIdColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.writerNicknameColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.regdateColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.memoColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.memoWriterComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.memoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Controls.Add(this.minBtn);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 30);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleLabel.ForeColor = System.Drawing.Color.Black;
            this.titleLabel.Location = new System.Drawing.Point(3, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(43, 15);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "쪽지함";
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
            this.closeBtn.Location = new System.Drawing.Point(708, 0);
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
            // minBtn
            // 
            this.minBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minBtn.FlatAppearance.BorderSize = 0;
            this.minBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.minBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.Font = new System.Drawing.Font("SansSerif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.minBtn.Location = new System.Drawing.Point(678, 0);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(30, 30);
            this.minBtn.TabIndex = 1;
            this.minBtn.TabStop = false;
            this.minBtn.Text = "_";
            this.minBtn.UseVisualStyleBackColor = true;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            this.minBtn.MouseEnter += new System.EventHandler(this.flatButton_MouseEnter);
            this.minBtn.MouseLeave += new System.EventHandler(this.flatButton_MouseLeave);
            // 
            // memoPanel
            // 
            this.memoPanel.Controls.Add(this.label1);
            this.memoPanel.Controls.Add(this.memoList);
            this.memoPanel.Controls.Add(this.memoWriterComboBox);
            this.memoPanel.Location = new System.Drawing.Point(1, 31);
            this.memoPanel.Name = "memoPanel";
            this.memoPanel.Size = new System.Drawing.Size(738, 577);
            this.memoPanel.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "분류";
            // 
            // memoList
            // 
            this.memoList.AllColumns.Add(this.writerIdColum);
            this.memoList.AllColumns.Add(this.writerNicknameColum);
            this.memoList.AllColumns.Add(this.regdateColum);
            this.memoList.AllColumns.Add(this.memoColum);
            this.memoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.memoList.CellEditUseWholeCell = false;
            this.memoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.writerIdColum,
            this.writerNicknameColum,
            this.regdateColum,
            this.memoColum});
            this.memoList.Cursor = System.Windows.Forms.Cursors.Default;
            this.memoList.FullRowSelect = true;
            this.memoList.HideSelection = false;
            this.memoList.Location = new System.Drawing.Point(3, 25);
            this.memoList.MultiSelect = false;
            this.memoList.Name = "memoList";
            this.memoList.Size = new System.Drawing.Size(732, 549);
            this.memoList.TabIndex = 0;
            this.memoList.TabStop = false;
            this.memoList.UseCompatibleStateImageBehavior = false;
            this.memoList.View = System.Windows.Forms.View.Details;
            this.memoList.ItemActivate += new System.EventHandler(this.memoList_ItemActivate);
            // 
            // writerIdColum
            // 
            this.writerIdColum.AspectName = "writerId";
            this.writerIdColum.AspectToStringFormat = "";
            this.writerIdColum.Text = "ID";
            this.writerIdColum.Width = 78;
            // 
            // writerNicknameColum
            // 
            this.writerNicknameColum.AspectName = "writerNickname";
            this.writerNicknameColum.Text = "닉네임";
            this.writerNicknameColum.Width = 89;
            // 
            // regdateColum
            // 
            this.regdateColum.AspectName = "regdate";
            this.regdateColum.Text = "날짜";
            this.regdateColum.Width = 150;
            // 
            // memoColum
            // 
            this.memoColum.AspectName = "msg";
            this.memoColum.Text = "내용";
            this.memoColum.Width = 390;
            // 
            // memoWriterComboBox
            // 
            this.memoWriterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.memoWriterComboBox.FormattingEnabled = true;
            this.memoWriterComboBox.Location = new System.Drawing.Point(39, 3);
            this.memoWriterComboBox.Name = "memoWriterComboBox";
            this.memoWriterComboBox.Size = new System.Drawing.Size(696, 20);
            this.memoWriterComboBox.TabIndex = 0;
            this.memoWriterComboBox.SelectedIndexChanged += new System.EventHandler(this.memoWriterComboBox_SelectedIndexChanged);
            // 
            // MemoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 611);
            this.Controls.Add(this.memoPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemoListForm";
            this.Text = "쪽지함";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemoListForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.form_BoderPaint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.memoPanel.ResumeLayout(false);
            this.memoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Panel memoPanel;
        private BrightIdeasSoftware.ObjectListView memoList;
        private BrightIdeasSoftware.OLVColumn writerIdColum;
        private BrightIdeasSoftware.OLVColumn writerNicknameColum;
        private BrightIdeasSoftware.OLVColumn memoColum;
        private System.Windows.Forms.ComboBox memoWriterComboBox;
        private BrightIdeasSoftware.OLVColumn regdateColum;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
    }
}