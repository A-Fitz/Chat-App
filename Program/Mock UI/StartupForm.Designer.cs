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
         this.label1 = new System.Windows.Forms.Label();
         this.loginButton = new System.Windows.Forms.Button();
         this.registerButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.label1.Location = new System.Drawing.Point(65, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(117, 25);
         this.label1.TabIndex = 1;
         this.label1.Text = "CHAT APP";
         // 
         // loginButton
         // 
         this.loginButton.Enabled = false;
         this.loginButton.Location = new System.Drawing.Point(86, 90);
         this.loginButton.Name = "loginButton";
         this.loginButton.Size = new System.Drawing.Size(75, 23);
         this.loginButton.TabIndex = 2;
         this.loginButton.Text = "Login";
         this.loginButton.UseVisualStyleBackColor = true;
         this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
         // 
         // registerButton
         // 
         this.registerButton.Enabled = false;
         this.registerButton.Location = new System.Drawing.Point(86, 133);
         this.registerButton.Name = "registerButton";
         this.registerButton.Size = new System.Drawing.Size(75, 23);
         this.registerButton.TabIndex = 3;
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
         this.Controls.Add(this.label1);
         this.Name = "StartupForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Chat App";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartupForm_FormClosed);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button loginButton;
      private System.Windows.Forms.Button registerButton;
   }
}