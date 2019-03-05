
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
            this.sendButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualPreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.messageStatusLabel = new System.Windows.Forms.Label();
            this.chatList = new System.Windows.Forms.ListBox();
            this.readMessagesTimer = new System.Windows.Forms.Timer(this.components);
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
            this.messageField.TextChanged += new System.EventHandler(this.messageField_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(697, 597);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
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
            this.listBox1.Location = new System.Drawing.Point(13, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(117, 238);
            this.listBox1.TabIndex = 2;
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
            this.visualPreferencesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
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
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.signInToolStripMenuItem.Text = "Sign In";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
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
            this.listBox2.Location = new System.Drawing.Point(13, 354);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 238);
            this.listBox2.TabIndex = 6;
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
            // messageStatusLabel
            // 
            this.messageStatusLabel.AutoSize = true;
            this.messageStatusLabel.Location = new System.Drawing.Point(208, 465);
            this.messageStatusLabel.Name = "messageStatusLabel";
            this.messageStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.messageStatusLabel.TabIndex = 8;
            // 
            // chatList
            // 
            this.chatList.FormattingEnabled = true;
            this.chatList.Location = new System.Drawing.Point(208, 67);
            this.chatList.Name = "chatList";
            this.chatList.Size = new System.Drawing.Size(564, 394);
            this.chatList.TabIndex = 9;
            // 
            // readMessagesTimer
            // 
            this.readMessagesTimer.Enabled = true;
            this.readMessagesTimer.Interval = 10000;
            this.readMessagesTimer.Tick += new System.EventHandler(this.readMessagesTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 644);
            this.Controls.Add(this.chatList);
            this.Controls.Add(this.messageStatusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.sendButton);
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
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualPreferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label messageStatusLabel;
        private System.Windows.Forms.ListBox chatList;
        private System.Windows.Forms.Timer readMessagesTimer;
    }
}

