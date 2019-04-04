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
         this.label1 = new System.Windows.Forms.Label();
         this.userNameText = new System.Windows.Forms.TextBox();
         this.connectButton = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.passwordText = new System.Windows.Forms.TextBox();
         this.backButton = new System.Windows.Forms.Button();
         this.LoginStatus = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.label1.Location = new System.Drawing.Point(206, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(76, 25);
         this.label1.TabIndex = 0;
         this.label1.Text = "LOGIN";
         // 
         // userNameText
         // 
         this.userNameText.Location = new System.Drawing.Point(139, 125);
         this.userNameText.Name = "userNameText";
         this.userNameText.Size = new System.Drawing.Size(212, 20);
         this.userNameText.TabIndex = 1;
         // 
         // connectButton
         // 
         this.connectButton.Location = new System.Drawing.Point(207, 235);
         this.connectButton.Name = "connectButton";
         this.connectButton.Size = new System.Drawing.Size(75, 23);
         this.connectButton.TabIndex = 2;
         this.connectButton.Text = "Login";
         this.connectButton.UseVisualStyleBackColor = true;
         this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(138, 109);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(53, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "username";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(138, 163);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(52, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "password";
         // 
         // passwordText
         // 
         this.passwordText.Location = new System.Drawing.Point(139, 179);
         this.passwordText.Name = "passwordText";
         this.passwordText.Size = new System.Drawing.Size(212, 20);
         this.passwordText.TabIndex = 5;
         this.passwordText.UseSystemPasswordChar = true;
         // 
         // backButton
         // 
         this.backButton.Location = new System.Drawing.Point(3, 331);
         this.backButton.Name = "backButton";
         this.backButton.Size = new System.Drawing.Size(75, 23);
         this.backButton.TabIndex = 15;
         this.backButton.Text = "Back";
         this.backButton.UseVisualStyleBackColor = true;
         this.backButton.Click += new System.EventHandler(this.backButton_Click);
         // 
         // LoginStatus
         // 
         this.LoginStatus.AutoSize = true;
         this.LoginStatus.Location = new System.Drawing.Point(138, 202);
         this.LoginStatus.Name = "LoginStatus";
         this.LoginStatus.Size = new System.Drawing.Size(109, 13);
         this.LoginStatus.TabIndex = 16;
         this.LoginStatus.Text = "12345678909834128";
         this.LoginStatus.Click += new System.EventHandler(this.LoginStatus_Click);
         // 
         // LoginForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(488, 356);
         this.Controls.Add(this.LoginStatus);
         this.Controls.Add(this.backButton);
         this.Controls.Add(this.passwordText);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.connectButton);
         this.Controls.Add(this.userNameText);
         this.Controls.Add(this.label1);
         this.Name = "LoginForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Login";
         this.Load += new System.EventHandler(this.LoginForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Button connectButton;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox passwordText;
      private System.Windows.Forms.Button backButton;
      private System.Windows.Forms.Label LoginStatus;
   }
}