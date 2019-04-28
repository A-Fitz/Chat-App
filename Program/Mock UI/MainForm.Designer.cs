namespace ChatApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
         this.components = new System.ComponentModel.Container();
         this.messageField = new System.Windows.Forms.TextBox();
         this.chatroomListBox = new System.Windows.Forms.ListBox();
         this.userListBox = new System.Windows.Forms.ListBox();
         this.chatListBox = new System.Windows.Forms.ListBox();
         this.readMessagesTimer = new System.Windows.Forms.Timer(this.components);
         this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
         this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
         this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
         this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.visualPreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.messageResponse = new MaterialSkin.Controls.MaterialLabel();
         this.messageResponseTimer = new System.Windows.Forms.Timer(this.components);
         this.sendButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.btnToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.subscribeChatroomBtn = new System.Windows.Forms.Button();
         this.newChatroomBtn = new System.Windows.Forms.Button();
         this.undoChatroomChangeBtn = new System.Windows.Forms.Button();
         this.materialContextMenuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // messageField
         // 
         this.messageField.Location = new System.Drawing.Point(208, 484);
         this.messageField.Multiline = true;
         this.messageField.Name = "messageField";
         this.messageField.Size = new System.Drawing.Size(564, 107);
         this.messageField.TabIndex = 0;
         this.messageField.TextChanged += new System.EventHandler(this.messageField_TextChanged);
         this.messageField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageField_KeyDown);
         // 
         // chatroomListBox
         // 
         this.chatroomListBox.FormattingEnabled = true;
         this.chatroomListBox.Location = new System.Drawing.Point(10, 109);
         this.chatroomListBox.Name = "chatroomListBox";
         this.chatroomListBox.Size = new System.Drawing.Size(117, 238);
         this.chatroomListBox.TabIndex = 2;
         this.chatroomListBox.SelectedIndexChanged += new System.EventHandler(this.chatroomListBox_SelectedIndexChanged);
         // 
         // userListBox
         // 
         this.userListBox.FormattingEnabled = true;
         this.userListBox.Location = new System.Drawing.Point(10, 407);
         this.userListBox.Name = "userListBox";
         this.userListBox.Size = new System.Drawing.Size(117, 225);
         this.userListBox.TabIndex = 6;
         // 
         // chatListBox
         // 
         this.chatListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
         this.chatListBox.FormattingEnabled = true;
         this.chatListBox.Location = new System.Drawing.Point(208, 93);
         this.chatListBox.Name = "chatListBox";
         this.chatListBox.Size = new System.Drawing.Size(564, 368);
         this.chatListBox.TabIndex = 9;
         this.chatListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.chatList_DrawItem);
         this.chatListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.chatList_MeasureItem);
         this.chatListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatList_KeyDown);
         // 
         // readMessagesTimer
         // 
         this.readMessagesTimer.Enabled = true;
         this.readMessagesTimer.Tick += new System.EventHandler(this.readMessagesTimer_Tick);
         // 
         // materialLabel1
         // 
         this.materialLabel1.AutoSize = true;
         this.materialLabel1.Depth = 0;
         this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
         this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.materialLabel1.Location = new System.Drawing.Point(6, 87);
         this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
         this.materialLabel1.Name = "materialLabel1";
         this.materialLabel1.Size = new System.Drawing.Size(84, 19);
         this.materialLabel1.TabIndex = 11;
         this.materialLabel1.Text = "Chatrooms";
         // 
         // materialLabel2
         // 
         this.materialLabel2.AutoSize = true;
         this.materialLabel2.Depth = 0;
         this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
         this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.materialLabel2.Location = new System.Drawing.Point(6, 385);
         this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
         this.materialLabel2.Name = "materialLabel2";
         this.materialLabel2.Size = new System.Drawing.Size(83, 19);
         this.materialLabel2.TabIndex = 12;
         this.materialLabel2.Text = "Chat Users";
         // 
         // materialContextMenuStrip1
         // 
         this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.materialContextMenuStrip1.Depth = 0;
         this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.logOutToolStripMenuItem});
         this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
         this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
         this.materialContextMenuStrip1.Size = new System.Drawing.Size(117, 48);
         // 
         // settingsToolStripMenuItem
         // 
         this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualPreferencesToolStripMenuItem});
         this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
         this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this.settingsToolStripMenuItem.Text = "Settings";
         // 
         // visualPreferencesToolStripMenuItem
         // 
         this.visualPreferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightToolStripMenuItem,
            this.darkToolStripMenuItem});
         this.visualPreferencesToolStripMenuItem.Name = "visualPreferencesToolStripMenuItem";
         this.visualPreferencesToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
         this.visualPreferencesToolStripMenuItem.Text = "Theme";
         // 
         // lightToolStripMenuItem
         // 
         this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
         this.lightToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
         this.lightToolStripMenuItem.Text = "Light";
         this.lightToolStripMenuItem.Click += new System.EventHandler(this.lightToolStripMenuItem_Click);
         // 
         // darkToolStripMenuItem
         // 
         this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
         this.darkToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
         this.darkToolStripMenuItem.Text = "Dark";
         this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
         // 
         // logOutToolStripMenuItem
         // 
         this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
         this.logOutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this.logOutToolStripMenuItem.Text = "Log out";
         this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
         // 
         // messageResponse
         // 
         this.messageResponse.AutoSize = true;
         this.messageResponse.BackColor = System.Drawing.Color.Transparent;
         this.messageResponse.Depth = 0;
         this.messageResponse.Font = new System.Drawing.Font("Roboto", 11F);
         this.messageResponse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.messageResponse.Location = new System.Drawing.Point(204, 462);
         this.messageResponse.MouseState = MaterialSkin.MouseState.HOVER;
         this.messageResponse.Name = "messageResponse";
         this.messageResponse.Size = new System.Drawing.Size(0, 19);
         this.messageResponse.TabIndex = 13;
         // 
         // messageResponseTimer
         // 
         this.messageResponseTimer.Enabled = true;
         this.messageResponseTimer.Interval = 5000;
         this.messageResponseTimer.Tick += new System.EventHandler(this.messageResponseTimer_Tick);
         // 
         // sendButton
         // 
         this.sendButton.Depth = 0;
         this.sendButton.Location = new System.Drawing.Point(725, 597);
         this.sendButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.sendButton.Name = "sendButton";
         this.sendButton.Primary = true;
         this.sendButton.Size = new System.Drawing.Size(47, 36);
         this.sendButton.TabIndex = 14;
         this.sendButton.Text = "Send";
         this.sendButton.UseVisualStyleBackColor = true;
         this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
         // 
         // subscribeChatroomBtn
         // 
         this.subscribeChatroomBtn.BackColor = System.Drawing.Color.Transparent;
         this.subscribeChatroomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.subscribeChatroomBtn.Image = global::Mock_UI.Properties.Resources.AddScreen_16x;
         this.subscribeChatroomBtn.Location = new System.Drawing.Point(104, 348);
         this.subscribeChatroomBtn.Name = "subscribeChatroomBtn";
         this.subscribeChatroomBtn.Size = new System.Drawing.Size(23, 23);
         this.subscribeChatroomBtn.TabIndex = 17;
         this.btnToolTip.SetToolTip(this.subscribeChatroomBtn, "Subscribe to Chatroom");
         this.subscribeChatroomBtn.UseVisualStyleBackColor = false;
         this.subscribeChatroomBtn.Click += new System.EventHandler(this.subscribeChatroomBtn_Click);
         // 
         // newChatroomBtn
         // 
         this.newChatroomBtn.BackColor = System.Drawing.Color.Transparent;
         this.newChatroomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.newChatroomBtn.Image = global::Mock_UI.Properties.Resources.NewWindow_16x;
         this.newChatroomBtn.Location = new System.Drawing.Point(80, 348);
         this.newChatroomBtn.Name = "newChatroomBtn";
         this.newChatroomBtn.Size = new System.Drawing.Size(23, 23);
         this.newChatroomBtn.TabIndex = 16;
         this.btnToolTip.SetToolTip(this.newChatroomBtn, "Create Chatroom");
         this.newChatroomBtn.UseVisualStyleBackColor = false;
         this.newChatroomBtn.Click += new System.EventHandler(this.newChatroomBtn_Click);
         // 
         // undoChatroomChangeBtn
         // 
         this.undoChatroomChangeBtn.BackColor = System.Drawing.Color.Transparent;
         this.undoChatroomChangeBtn.Enabled = false;
         this.undoChatroomChangeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.undoChatroomChangeBtn.ForeColor = System.Drawing.SystemColors.ControlText;
         this.undoChatroomChangeBtn.Image = global::Mock_UI.Properties.Resources.Undo_16x;
         this.undoChatroomChangeBtn.Location = new System.Drawing.Point(10, 348);
         this.undoChatroomChangeBtn.Name = "undoChatroomChangeBtn";
         this.undoChatroomChangeBtn.Size = new System.Drawing.Size(23, 23);
         this.undoChatroomChangeBtn.TabIndex = 15;
         this.btnToolTip.SetToolTip(this.undoChatroomChangeBtn, "Undo Chatroom Select");
         this.undoChatroomChangeBtn.UseVisualStyleBackColor = false;
         this.undoChatroomChangeBtn.Click += new System.EventHandler(this.undoChatroomChangeBtn_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 644);
         this.ContextMenuStrip = this.materialContextMenuStrip1;
         this.Controls.Add(this.subscribeChatroomBtn);
         this.Controls.Add(this.newChatroomBtn);
         this.Controls.Add(this.undoChatroomChangeBtn);
         this.Controls.Add(this.sendButton);
         this.Controls.Add(this.messageResponse);
         this.Controls.Add(this.materialLabel2);
         this.Controls.Add(this.materialLabel1);
         this.Controls.Add(this.chatListBox);
         this.Controls.Add(this.userListBox);
         this.Controls.Add(this.chatroomListBox);
         this.Controls.Add(this.messageField);
         this.Name = "MainForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Chat App";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
         this.materialContextMenuStrip1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.TextBox messageField;
        private System.Windows.Forms.ListBox chatroomListBox;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.ListBox chatListBox;
        private System.Windows.Forms.Timer readMessagesTimer;
      private MaterialSkin.Controls.MaterialLabel materialLabel1;
      private MaterialSkin.Controls.MaterialLabel materialLabel2;
      private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem visualPreferencesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
      private MaterialSkin.Controls.MaterialLabel messageResponse;
      private System.Windows.Forms.Timer messageResponseTimer;
      private MaterialSkin.Controls.MaterialRaisedButton sendButton;
      private System.Windows.Forms.Button undoChatroomChangeBtn;
      private System.Windows.Forms.Button newChatroomBtn;
      private System.Windows.Forms.Button subscribeChatroomBtn;
      private System.Windows.Forms.ToolTip btnToolTip;
   }
}

