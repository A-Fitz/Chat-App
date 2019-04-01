namespace Mock_UI
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
         this.label1 = new System.Windows.Forms.Label();
         this.passwordText = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.userNameText = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.registerButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.label1.Location = new System.Drawing.Point(185, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(118, 25);
         this.label1.TabIndex = 1;
         this.label1.Text = "REGISTER";
         // 
         // passwordText
         // 
         this.passwordText.Location = new System.Drawing.Point(139, 179);
         this.passwordText.Name = "passwordText";
         this.passwordText.Size = new System.Drawing.Size(212, 20);
         this.passwordText.TabIndex = 9;
         this.passwordText.UseSystemPasswordChar = true;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(138, 163);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(52, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "password";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(138, 109);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(53, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "username";
         // 
         // userNameText
         // 
         this.userNameText.Location = new System.Drawing.Point(139, 126);
         this.userNameText.Name = "userNameText";
         this.userNameText.Size = new System.Drawing.Size(212, 20);
         this.userNameText.TabIndex = 6;
         this.userNameText.TextChanged += new System.EventHandler(this.userNameText_TextChanged);
         this.userNameText.Leave += new System.EventHandler(this.userNameText_Leave);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(188, 164);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(94, 12);
         this.label4.TabIndex = 10;
         this.label4.Text = "(at least 4 characters)";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(188, 110);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(188, 12);
         this.label5.TabIndex = 12;
         this.label5.Text = "(letters, numbers, underscores, dashes only)";
         // 
         // registerButton
         // 
         this.registerButton.Location = new System.Drawing.Point(207, 235);
         this.registerButton.Name = "registerButton";
         this.registerButton.Size = new System.Drawing.Size(75, 23);
         this.registerButton.TabIndex = 13;
         this.registerButton.Text = "Register";
         this.registerButton.UseVisualStyleBackColor = true;
         this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
         // 
         // RegisterForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(488, 356);
         this.Controls.Add(this.registerButton);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.passwordText);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.userNameText);
         this.Controls.Add(this.label1);
         this.Name = "RegisterForm";
         this.Text = "Register";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox passwordText;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox userNameText;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button registerButton;
   }
}