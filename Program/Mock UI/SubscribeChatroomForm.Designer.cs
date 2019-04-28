namespace Mock_UI
{
   partial class SubscribeChatroomForm
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
         this.joinBtn = new MaterialSkin.Controls.MaterialRaisedButton();
         this.passwordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.chatroomIDField = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.responseLabel = new MaterialSkin.Controls.MaterialLabel();
         this.SuspendLayout();
         // 
         // joinBtn
         // 
         this.joinBtn.Depth = 0;
         this.joinBtn.Location = new System.Drawing.Point(82, 173);
         this.joinBtn.MouseState = MaterialSkin.MouseState.HOVER;
         this.joinBtn.Name = "joinBtn";
         this.joinBtn.Primary = true;
         this.joinBtn.Size = new System.Drawing.Size(75, 23);
         this.joinBtn.TabIndex = 5;
         this.joinBtn.Text = "Join";
         this.joinBtn.UseVisualStyleBackColor = true;
         this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
         // 
         // passwordField
         // 
         this.passwordField.Depth = 0;
         this.passwordField.Hint = "password";
         this.passwordField.Location = new System.Drawing.Point(12, 135);
         this.passwordField.MouseState = MaterialSkin.MouseState.HOVER;
         this.passwordField.Name = "passwordField";
         this.passwordField.PasswordChar = '*';
         this.passwordField.SelectedText = "";
         this.passwordField.SelectionLength = 0;
         this.passwordField.SelectionStart = 0;
         this.passwordField.Size = new System.Drawing.Size(222, 23);
         this.passwordField.TabIndex = 4;
         this.passwordField.UseSystemPasswordChar = false;
         // 
         // chatroomIDField
         // 
         this.chatroomIDField.Depth = 0;
         this.chatroomIDField.Hint = "chatroom id";
         this.chatroomIDField.Location = new System.Drawing.Point(12, 107);
         this.chatroomIDField.MouseState = MaterialSkin.MouseState.HOVER;
         this.chatroomIDField.Name = "chatroomIDField";
         this.chatroomIDField.PasswordChar = '\0';
         this.chatroomIDField.SelectedText = "";
         this.chatroomIDField.SelectionLength = 0;
         this.chatroomIDField.SelectionStart = 0;
         this.chatroomIDField.Size = new System.Drawing.Size(222, 23);
         this.chatroomIDField.TabIndex = 3;
         this.chatroomIDField.UseSystemPasswordChar = false;
         // 
         // responseLabel
         // 
         this.responseLabel.AutoSize = true;
         this.responseLabel.Depth = 0;
         this.responseLabel.Font = new System.Drawing.Font("Roboto", 11F);
         this.responseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.responseLabel.Location = new System.Drawing.Point(12, 75);
         this.responseLabel.MouseState = MaterialSkin.MouseState.HOVER;
         this.responseLabel.Name = "responseLabel";
         this.responseLabel.Size = new System.Drawing.Size(0, 19);
         this.responseLabel.TabIndex = 6;
         // 
         // SubscribeChatroomForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(246, 222);
         this.Controls.Add(this.responseLabel);
         this.Controls.Add(this.joinBtn);
         this.Controls.Add(this.passwordField);
         this.Controls.Add(this.chatroomIDField);
         this.Name = "SubscribeChatroomForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Subscribe to Chatroom";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MaterialSkin.Controls.MaterialRaisedButton joinBtn;
      private MaterialSkin.Controls.MaterialSingleLineTextField passwordField;
      private MaterialSkin.Controls.MaterialSingleLineTextField chatroomIDField;
      private MaterialSkin.Controls.MaterialLabel responseLabel;
   }
}