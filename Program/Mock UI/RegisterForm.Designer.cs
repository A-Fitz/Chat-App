namespace ChatApp
{
   partial class RegisterForm
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
         this.userNameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.passwordText = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.registerButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.backButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.registrationStatus = new MaterialSkin.Controls.MaterialLabel();
         this.SuspendLayout();
         // 
         // userNameText
         // 
         this.userNameText.Depth = 0;
         this.userNameText.Hint = "username (letters, numbers, dashes)";
         this.userNameText.Location = new System.Drawing.Point(132, 148);
         this.userNameText.MouseState = MaterialSkin.MouseState.HOVER;
         this.userNameText.Name = "userNameText";
         this.userNameText.PasswordChar = '\0';
         this.userNameText.SelectedText = "";
         this.userNameText.SelectionLength = 0;
         this.userNameText.SelectionStart = 0;
         this.userNameText.Size = new System.Drawing.Size(255, 23);
         this.userNameText.TabIndex = 1;
         this.userNameText.UseSystemPasswordChar = false;
         this.userNameText.Leave += new System.EventHandler(this.userNameText_Leave);
         this.userNameText.TextChanged += new System.EventHandler(this.userNameText_TextChanged);
         // 
         // passwordText
         // 
         this.passwordText.Depth = 0;
         this.passwordText.Hint = "password (4 or more characters)";
         this.passwordText.Location = new System.Drawing.Point(132, 190);
         this.passwordText.MouseState = MaterialSkin.MouseState.HOVER;
         this.passwordText.Name = "passwordText";
         this.passwordText.PasswordChar = '*';
         this.passwordText.SelectedText = "";
         this.passwordText.SelectionLength = 0;
         this.passwordText.SelectionStart = 0;
         this.passwordText.Size = new System.Drawing.Size(255, 23);
         this.passwordText.TabIndex = 2;
         this.passwordText.UseSystemPasswordChar = false;
         this.passwordText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordText_KeyDown);
         // 
         // registerButton
         // 
         this.registerButton.Depth = 0;
         this.registerButton.Location = new System.Drawing.Point(207, 236);
         this.registerButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.registerButton.Name = "registerButton";
         this.registerButton.Primary = true;
         this.registerButton.Size = new System.Drawing.Size(75, 31);
         this.registerButton.TabIndex = 3;
         this.registerButton.Text = "Register";
         this.registerButton.UseVisualStyleBackColor = true;
         this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
         // 
         // backButton
         // 
         this.backButton.Depth = 0;
         this.backButton.Location = new System.Drawing.Point(12, 313);
         this.backButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.backButton.Name = "backButton";
         this.backButton.Primary = true;
         this.backButton.Size = new System.Drawing.Size(75, 31);
         this.backButton.TabIndex = 16;
         this.backButton.Text = "Back";
         this.backButton.UseVisualStyleBackColor = true;
         this.backButton.Click += new System.EventHandler(this.backButton_Click);
         // 
         // registrationStatus
         // 
         this.registrationStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.registrationStatus.BackColor = System.Drawing.Color.Transparent;
         this.registrationStatus.Depth = 0;
         this.registrationStatus.Font = new System.Drawing.Font("Roboto", 11F);
         this.registrationStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.registrationStatus.Location = new System.Drawing.Point(68, 77);
         this.registrationStatus.MouseState = MaterialSkin.MouseState.HOVER;
         this.registrationStatus.Name = "registrationStatus";
         this.registrationStatus.Size = new System.Drawing.Size(353, 19);
         this.registrationStatus.TabIndex = 22;
         this.registrationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // RegisterForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(488, 356);
         this.Controls.Add(this.registrationStatus);
         this.Controls.Add(this.backButton);
         this.Controls.Add(this.registerButton);
         this.Controls.Add(this.passwordText);
         this.Controls.Add(this.userNameText);
         this.Name = "RegisterForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Register";
         this.ResumeLayout(false);

      }

      #endregion
      private MaterialSkin.Controls.MaterialSingleLineTextField userNameText;
      private MaterialSkin.Controls.MaterialSingleLineTextField passwordText;
      private MaterialSkin.Controls.MaterialRaisedButton registerButton;
      private MaterialSkin.Controls.MaterialRaisedButton backButton;
      private MaterialSkin.Controls.MaterialLabel registrationStatus;
   }
}