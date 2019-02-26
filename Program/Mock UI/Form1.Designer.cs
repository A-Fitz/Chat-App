namespace Mock_UI
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.chatroomList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualPreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayField = new System.Windows.Forms.TextBox();
            this.chatUsersList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageField
            // 
            this.messageField.Location = new System.Drawing.Point(208, 484);
            this.messageField.Multiline = true;
            this.messageField.Name = "messageField";
            this.messageField.Size = new System.Drawing.Size(564, 107);
            this.messageField.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chatroomList
            // 
            this.chatroomList.FormattingEnabled = true;
            this.chatroomList.Items.AddRange(new object[] {
            "Chatroom 1",
            "Chatroom 2",
            "Chatroom 3",
            "Chatroom 4",
            "Chatroom 5",
            "Chatroom 6",
            "Chatroom 7",
            "Chatroom 8",
            "Chatroom 9",
            "Chatroom 10",
            "Chatroom 11",
            "Chatroom 12",
            "Chatroom 13",
            "Chatroom 14",
            "Chatroom 15",
            "Chatroom 16",
            "Chatroom 17",
            "Chatroom 18",
            "Chatroom 19",
            "Chatroom 20",
            "Chatroom 21",
            "Chatroom 22",
            "Chatroom 23",
            "Chatroom 24",
            "Chatroom 25",
            "Chatroom 26",
            "Chatroom 27",
            "Chatroom 28",
            "Chatroom 29",
            "Chatroom 30",
            "Chatroom 31",
            "Chatroom 32",
            "Chatroom 33",
            "Chatroom 34",
            "Chatroom 35"});
            this.chatroomList.Location = new System.Drawing.Point(13, 67);
            this.chatroomList.Name = "chatroomList";
            this.chatroomList.Size = new System.Drawing.Size(117, 238);
            this.chatroomList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chatrooms";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualPreferencesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem1.Text = "Edit";
            // 
            // visualPreferencesToolStripMenuItem
            // 
            this.visualPreferencesToolStripMenuItem.Name = "visualPreferencesToolStripMenuItem";
            this.visualPreferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.visualPreferencesToolStripMenuItem.Text = "Visual Preferences";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signInToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.signInToolStripMenuItem.Text = "Sign In";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // displayField
            // 
            this.displayField.BackColor = System.Drawing.SystemColors.Control;
            this.displayField.Location = new System.Drawing.Point(208, 67);
            this.displayField.Multiline = true;
            this.displayField.Name = "displayField";
            this.displayField.ReadOnly = true;
            this.displayField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.displayField.Size = new System.Drawing.Size(564, 387);
            this.displayField.TabIndex = 5;
            // 
            // chatUsersList
            // 
            this.chatUsersList.FormattingEnabled = true;
            this.chatUsersList.Items.AddRange(new object[] {
            "User 1",
            "User 2",
            "User 3",
            "User 4",
            "User 5",
            "User 6",
            "User 7",
            "User 8",
            "User 9",
            "User 10",
            "User 11",
            "User 12",
            "User 13",
            "User 14",
            "User 15",
            "User 16",
            "User 17",
            "User 18",
            "User 19",
            "User 20",
            "User 21"});
            this.chatUsersList.Location = new System.Drawing.Point(13, 354);
            this.chatUsersList.Name = "chatUsersList";
            this.chatUsersList.Size = new System.Drawing.Size(120, 238);
            this.chatUsersList.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chat Users";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 644);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chatUsersList);
            this.Controls.Add(this.displayField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatroomList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.messageField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageField;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox chatroomList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualPreferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.TextBox displayField;
        private System.Windows.Forms.ListBox chatUsersList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

