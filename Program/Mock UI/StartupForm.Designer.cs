namespace ChatApp
{
   partial class StartupForm
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
         this.loginButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.registerButton = new MaterialSkin.Controls.MaterialRaisedButton();
         this.SuspendLayout();
         // 
         // loginButton
         // 
         this.loginButton.Depth = 0;
         this.loginButton.Enabled = false;
         this.loginButton.Location = new System.Drawing.Point(86, 96);
         this.loginButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.loginButton.Name = "loginButton";
         this.loginButton.Primary = true;
         this.loginButton.Size = new System.Drawing.Size(75, 31);
         this.loginButton.TabIndex = 3;
         this.loginButton.Text = "Login";
         this.loginButton.UseVisualStyleBackColor = true;
         this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
         // 
         // registerButton
         // 
         this.registerButton.Depth = 0;
         this.registerButton.Enabled = false;
         this.registerButton.Location = new System.Drawing.Point(86, 151);
         this.registerButton.MouseState = MaterialSkin.MouseState.HOVER;
         this.registerButton.Name = "registerButton";
         this.registerButton.Primary = true;
         this.registerButton.Size = new System.Drawing.Size(75, 31);
         this.registerButton.TabIndex = 4;
         this.registerButton.Text = "Register";
         this.registerButton.UseVisualStyleBackColor = true;
         this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
         // 
         // StartupForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(246, 222);
         this.Controls.Add(this.registerButton);
         this.Controls.Add(this.loginButton);
         this.Name = "StartupForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Chat App";
         this.ResumeLayout(false);

      }

      #endregion
      private MaterialSkin.Controls.MaterialRaisedButton loginButton;
      private MaterialSkin.Controls.MaterialRaisedButton registerButton;
   }
}