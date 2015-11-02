
namespace KaiXinAssist
{
    partial class FormFriend
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxReceive = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chklstFriend = new System.Windows.Forms.CheckedListBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnAllSelect = new System.Windows.Forms.Button();
            this.grpFriendList = new System.Windows.Forms.GroupBox();
            this.chkDispOnline = new System.Windows.Forms.CheckBox();
            this.lblChooseFreinds = new System.Windows.Forms.Label();
            this.lblReceive = new System.Windows.Forms.Label();
            this.grpSend = new System.Windows.Forms.GroupBox();
            this.txtReceiverID = new System.Windows.Forms.TextBox();
            this.lblReceiverID = new System.Windows.Forms.Label();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPgSendMessage = new System.Windows.Forms.TabPage();
            this.tbPgReceiveMessage = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chklstReceiveList = new System.Windows.Forms.CheckedListBox();
            this.txtReceiveContent = new System.Windows.Forms.TextBox();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.grpContent = new System.Windows.Forms.GroupBox();
            this.grpFriendList.SuspendLayout();
            this.grpSend.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbPgSendMessage.SuspendLayout();
            this.tbPgReceiveMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxReceive
            // 
            this.txtBoxReceive.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtBoxReceive.Location = new System.Drawing.Point(188, 43);
            this.txtBoxReceive.Multiline = true;
            this.txtBoxReceive.Name = "txtBoxReceive";
            this.txtBoxReceive.ReadOnly = true;
            this.txtBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxReceive.Size = new System.Drawing.Size(333, 72);
            this.txtBoxReceive.TabIndex = 1;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(188, 190);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(333, 114);
            this.txtContent.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(263, 310);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发　送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(369, 310);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清　空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chklstFriend
            // 
            this.chklstFriend.CheckOnClick = true;
            this.chklstFriend.FormattingEnabled = true;
            this.chklstFriend.Location = new System.Drawing.Point(16, 43);
            this.chklstFriend.Name = "chklstFriend";
            this.chklstFriend.Size = new System.Drawing.Size(142, 260);
            this.chklstFriend.TabIndex = 5;
            this.chklstFriend.SelectedIndexChanged += new System.EventHandler(this.chklstFriend_SelectedIndexChanged);
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(9, 167);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(53, 12);
            this.lblContent.TabIndex = 6;
            this.lblContent.Text = "信息内容";
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.Location = new System.Drawing.Point(7, 299);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(49, 23);
            this.btnAllSelect.TabIndex = 7;
            this.btnAllSelect.Text = "全　选";
            this.btnAllSelect.UseVisualStyleBackColor = true;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // grpFriendList
            // 
            this.grpFriendList.Controls.Add(this.chkDispOnline);
            this.grpFriendList.Controls.Add(this.lblChooseFreinds);
            this.grpFriendList.Controls.Add(this.btnAllSelect);
            this.grpFriendList.Location = new System.Drawing.Point(9, 9);
            this.grpFriendList.Name = "grpFriendList";
            this.grpFriendList.Size = new System.Drawing.Size(155, 334);
            this.grpFriendList.TabIndex = 9;
            this.grpFriendList.TabStop = false;
            this.grpFriendList.Text = "好友列表";
            // 
            // chkDispOnline
            // 
            this.chkDispOnline.AutoSize = true;
            this.chkDispOnline.Location = new System.Drawing.Point(71, 16);
            this.chkDispOnline.Name = "chkDispOnline";
            this.chkDispOnline.Size = new System.Drawing.Size(84, 16);
            this.chkDispOnline.TabIndex = 13;
            this.chkDispOnline.Text = "仅显示在线";
            this.chkDispOnline.UseVisualStyleBackColor = true;
            this.chkDispOnline.CheckedChanged += new System.EventHandler(this.chkDispOnline_CheckedChanged);
            // 
            // lblChooseFreinds
            // 
            this.lblChooseFreinds.AutoSize = true;
            this.lblChooseFreinds.Location = new System.Drawing.Point(8, 17);
            this.lblChooseFreinds.Name = "lblChooseFreinds";
            this.lblChooseFreinds.Size = new System.Drawing.Size(29, 12);
            this.lblChooseFreinds.TabIndex = 8;
            this.lblChooseFreinds.Text = "选择";
            // 
            // lblReceive
            // 
            this.lblReceive.AutoSize = true;
            this.lblReceive.Location = new System.Drawing.Point(9, 21);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(41, 12);
            this.lblReceive.TabIndex = 11;
            this.lblReceive.Text = "接收者";
            // 
            // grpSend
            // 
            this.grpSend.Controls.Add(this.txtReceiverID);
            this.grpSend.Controls.Add(this.lblReceiverID);
            this.grpSend.Controls.Add(this.chkComment);
            this.grpSend.Controls.Add(this.lblReceive);
            this.grpSend.Controls.Add(this.lblContent);
            this.grpSend.Location = new System.Drawing.Point(177, 8);
            this.grpSend.Name = "grpSend";
            this.grpSend.Size = new System.Drawing.Size(358, 335);
            this.grpSend.TabIndex = 12;
            this.grpSend.TabStop = false;
            this.grpSend.Text = "发送信息";
            // 
            // txtReceiverID
            // 
            this.txtReceiverID.Location = new System.Drawing.Point(11, 126);
            this.txtReceiverID.Multiline = true;
            this.txtReceiverID.Name = "txtReceiverID";
            this.txtReceiverID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiverID.Size = new System.Drawing.Size(333, 38);
            this.txtReceiverID.TabIndex = 14;
            // 
            // lblReceiverID
            // 
            this.lblReceiverID.AutoSize = true;
            this.lblReceiverID.Location = new System.Drawing.Point(9, 110);
            this.lblReceiverID.Name = "lblReceiverID";
            this.lblReceiverID.Size = new System.Drawing.Size(53, 12);
            this.lblReceiverID.TabIndex = 13;
            this.lblReceiverID.Text = "接收者ID";
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Location = new System.Drawing.Point(11, 307);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(60, 16);
            this.chkComment.TabIndex = 12;
            this.chkComment.Text = "留言本";
            this.chkComment.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPgSendMessage);
            this.tabControl1.Controls.Add(this.tbPgReceiveMessage);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 376);
            this.tabControl1.TabIndex = 13;
            // 
            // tbPgSendMessage
            // 
            this.tbPgSendMessage.Controls.Add(this.chklstFriend);
            this.tbPgSendMessage.Controls.Add(this.grpFriendList);
            this.tbPgSendMessage.Controls.Add(this.txtBoxReceive);
            this.tbPgSendMessage.Controls.Add(this.btnClear);
            this.tbPgSendMessage.Controls.Add(this.btnSend);
            this.tbPgSendMessage.Controls.Add(this.txtContent);
            this.tbPgSendMessage.Controls.Add(this.grpSend);
            this.tbPgSendMessage.Location = new System.Drawing.Point(4, 22);
            this.tbPgSendMessage.Name = "tbPgSendMessage";
            this.tbPgSendMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgSendMessage.Size = new System.Drawing.Size(543, 350);
            this.tbPgSendMessage.TabIndex = 0;
            this.tbPgSendMessage.Text = "发送信息";
            this.tbPgSendMessage.UseVisualStyleBackColor = true;
            // 
            // tbPgReceiveMessage
            // 
            this.tbPgReceiveMessage.Controls.Add(this.btnRefresh);
            this.tbPgReceiveMessage.Controls.Add(this.chklstReceiveList);
            this.tbPgReceiveMessage.Controls.Add(this.txtReceiveContent);
            this.tbPgReceiveMessage.Controls.Add(this.grpList);
            this.tbPgReceiveMessage.Controls.Add(this.grpContent);
            this.tbPgReceiveMessage.Location = new System.Drawing.Point(4, 22);
            this.tbPgReceiveMessage.Name = "tbPgReceiveMessage";
            this.tbPgReceiveMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgReceiveMessage.Size = new System.Drawing.Size(543, 350);
            this.tbPgReceiveMessage.TabIndex = 1;
            this.tbPgReceiveMessage.Text = "收件箱";
            this.tbPgReceiveMessage.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 320);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chklstReceiveList
            // 
            this.chklstReceiveList.CheckOnClick = true;
            this.chklstReceiveList.FormattingEnabled = true;
            this.chklstReceiveList.Location = new System.Drawing.Point(19, 28);
            this.chklstReceiveList.Name = "chklstReceiveList";
            this.chklstReceiveList.Size = new System.Drawing.Size(126, 276);
            this.chklstReceiveList.TabIndex = 2;
            this.chklstReceiveList.SelectedIndexChanged += new System.EventHandler(this.chklstReceiveList_SelectedIndexChanged);
            // 
            // txtReceiveContent
            // 
            this.txtReceiveContent.Location = new System.Drawing.Point(175, 28);
            this.txtReceiveContent.Multiline = true;
            this.txtReceiveContent.Name = "txtReceiveContent";
            this.txtReceiveContent.ReadOnly = true;
            this.txtReceiveContent.Size = new System.Drawing.Size(341, 276);
            this.txtReceiveContent.TabIndex = 1;
            // 
            // grpList
            // 
            this.grpList.Location = new System.Drawing.Point(6, 6);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(154, 308);
            this.grpList.TabIndex = 4;
            this.grpList.TabStop = false;
            this.grpList.Text = "信件列表";
            // 
            // grpContent
            // 
            this.grpContent.Location = new System.Drawing.Point(166, 6);
            this.grpContent.Name = "grpContent";
            this.grpContent.Size = new System.Drawing.Size(356, 308);
            this.grpContent.TabIndex = 5;
            this.grpContent.TabStop = false;
            this.grpContent.Text = "信件内容";
            // 
            // FormFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 390);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormFriend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开心网管理";
            this.Load += new System.EventHandler(this.FormFriend_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFriend_FormClosing);
            this.grpFriendList.ResumeLayout(false);
            this.grpFriendList.PerformLayout();
            this.grpSend.ResumeLayout(false);
            this.grpSend.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbPgSendMessage.ResumeLayout(false);
            this.tbPgSendMessage.PerformLayout();
            this.tbPgReceiveMessage.ResumeLayout(false);
            this.tbPgReceiveMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxReceive;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckedListBox chklstFriend;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Button btnAllSelect;
        private System.Windows.Forms.GroupBox grpFriendList;
        private System.Windows.Forms.Label lblReceive;
        private System.Windows.Forms.GroupBox grpSend;
        private System.Windows.Forms.Label lblChooseFreinds;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPgSendMessage;
        private System.Windows.Forms.TabPage tbPgReceiveMessage;
        private System.Windows.Forms.CheckBox chkDispOnline;
        private System.Windows.Forms.TextBox txtReceiveContent;
        private System.Windows.Forms.CheckedListBox chklstReceiveList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.GroupBox grpContent;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.Label lblReceiverID;
        private System.Windows.Forms.TextBox txtReceiverID;
    }
}