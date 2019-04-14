namespace ChatApp
{
    partial class LoginForm
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
         this.userNameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.passwordText = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.connectButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.backButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.loginStatusTimer = new System.Windows.Forms.Timer(this.components);
         this.loginStatus = new MaterialSkin.Controls.MaterialLabel();
         this.SuspendLayout();
         // 
         // userNameText
         // 
         this.userNameText.Depth = 0;
         this.userNameText.Hint = "username";
         this.userNameText.Location = new System.Drawing.Point(132, 148);
         this.userNameText.MouseState = MaterialSkin.MouseState.HOVER;
         this.userNameText.Name = "userNameText";
         this.userNameText.PasswordChar = '\0';
         this.userNameText.SelectedText = "";
         this.userNameText.SelectionLength = 0;
         this.userNameText.SelectionStart = 0;
         this.userNameText.Size = new System.Drawing.Size(225, 23);
         this.userNameText.TabIndex = 1;
         this.userNameText.UseSystemPasswordChar = false;
         // 
         // passwordText
         // 
         this.passwordText.Depth = 0;
         this.passwordText.Hint = "password";
         this.passwordText.Location = new System.Drawing.Point(132, 190);
         this.passwordText.MouseState = MaterialSkin.MouseState.HOVER;
         this.passwordText.Name = "passwordText";
         this.passwordText.PasswordChar = '*';
         this.passwordText.SelectedText = "";
         this.passwordText.SelectionLength = 0;
         this.passwordText.SelectionStart = 0;
         this.passwordText.Size = new System.Drawing.Size(225, 23);
         this.passwordText.TabIndex = 2;
         this.passwordText.UseSystemPasswordChar = false;
         this.passwordText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordText_KeyDown);
         // 
         // connectButton
         // 
         this.connectButton.Depth = 0;
         this.connectButton.Location = new System.Drawing.Point(207, 236);
         this.connectButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.connectButton.Name = "connectButton";
         this.connectButton.Primary = true;
         this.connectButton.Size = new System.Drawing.Size(75, 31);
         this.connectButton.TabIndex = 3;
         this.connectButton.Text = "Login";
         this.connectButton.UseVisualStyleBackColor = true;
         this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
         // 
         // backButton
         // 
         this.backButton.Depth = 0;
         this.backButton.Location = new System.Drawing.Point(12, 313);
         this.backButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.backButton.Name = "backButton";
         this.backButton.Primary = true;
         this.backButton.Size = new System.Drawing.Size(75, 31);
         this.backButton.TabIndex = 4;
         this.backButton.Text = "Back";
         this.backButton.UseVisualStyleBackColor = true;
         this.backButton.Click += new System.EventHandler(this.backButton_Click);
         // 
         // loginStatusTimer
         // 
         this.loginStatusTimer.Interval = 5000;
         this.loginStatusTimer.Tick += new System.EventHandler(this.loginStatusTimer_Tick);
         // 
         // loginStatus
         // 
         this.loginStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.loginStatus.BackColor = System.Drawing.Color.Transparent;
         this.loginStatus.Depth = 0;
         this.loginStatus.Font = new System.Drawing.Font("Roboto", 11F);
         this.loginStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.loginStatus.Location = new System.Drawing.Point(68, 77);
         this.loginStatus.MouseState = MaterialSkin.MouseState.HOVER;
         this.loginStatus.Name = "loginStatus";
         this.loginStatus.Size = new System.Drawing.Size(353, 19);
         this.loginStatus.TabIndex = 21;
         this.loginStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // LoginForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(488, 356);
         this.Controls.Add(this.loginStatus);
         this.Controls.Add(this.backButton);
         this.Controls.Add(this.connectButton);
         this.Controls.Add(this.passwordText);
         this.Controls.Add(this.userNameText);
         this.Name = "LoginForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Login";
         this.ResumeLayout(false);

        }

        #endregion
      private MaterialSkin.Controls.MaterialSingleLineTextField userNameText;
      private MaterialSkin.Controls.MaterialSingleLineTextField passwordText;
      private MaterialSkin.Controls.MaterialRaisedButton connectButton;
      private MaterialSkin.Controls.MaterialRaisedButton backButton;
      private System.Windows.Forms.Timer loginStatusTimer;
      private MaterialSkin.Controls.MaterialLabel loginStatus;
   }
}