namespace Mock_UI
{
    partial class Form2
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
         this.ipAddressText = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.portNumeric = new System.Windows.Forms.NumericUpDown();
         ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
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
         this.userNameText.Location = new System.Drawing.Point(136, 80);
         this.userNameText.Name = "userNameText";
         this.userNameText.Size = new System.Drawing.Size(212, 20);
         this.userNameText.TabIndex = 1;
         // 
         // connectButton
         // 
         this.connectButton.Location = new System.Drawing.Point(207, 283);
         this.connectButton.Name = "connectButton";
         this.connectButton.Size = new System.Drawing.Size(75, 23);
         this.connectButton.TabIndex = 2;
         this.connectButton.Text = "Connect";
         this.connectButton.UseVisualStyleBackColor = true;
         this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(135, 64);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(53, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "username";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(135, 118);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(52, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "password";
         // 
         // passwordText
         // 
         this.passwordText.Location = new System.Drawing.Point(136, 134);
         this.passwordText.Name = "passwordText";
         this.passwordText.Size = new System.Drawing.Size(212, 20);
         this.passwordText.TabIndex = 5;
         this.passwordText.UseSystemPasswordChar = true;
         // 
         // ipAddressText
         // 
         this.ipAddressText.Location = new System.Drawing.Point(136, 234);
         this.ipAddressText.Name = "ipAddressText";
         this.ipAddressText.Size = new System.Drawing.Size(146, 20);
         this.ipAddressText.TabIndex = 6;
         this.ipAddressText.Text = "127.0.0.1";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(135, 218);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(55, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "ip address";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(286, 218);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(25, 13);
         this.label5.TabIndex = 9;
         this.label5.Text = "port";
         // 
         // portNumeric
         // 
         this.portNumeric.Location = new System.Drawing.Point(289, 234);
         this.portNumeric.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
         this.portNumeric.Name = "portNumeric";
         this.portNumeric.Size = new System.Drawing.Size(59, 20);
         this.portNumeric.TabIndex = 10;
         this.portNumeric.Value = new decimal(new int[] {
            12345,
            0,
            0,
            0});
         // 
         // Form2
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(488, 356);
         this.Controls.Add(this.portNumeric);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.ipAddressText);
         this.Controls.Add(this.passwordText);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.connectButton);
         this.Controls.Add(this.userNameText);
         this.Controls.Add(this.label1);
         this.Name = "Form2";
         this.Text = "Connect To Server";
         ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
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
      private System.Windows.Forms.TextBox ipAddressText;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.NumericUpDown portNumeric;
   }
}