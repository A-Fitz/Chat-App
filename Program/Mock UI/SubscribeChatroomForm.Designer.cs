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
         this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.chatroomNameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.SuspendLayout();
         // 
         // joinBtn
         // 
         this.joinBtn.Depth = 0;
         this.joinBtn.Location = new System.Drawing.Point(82, 164);
         this.joinBtn.MouseState = MaterialSkin.MouseState.HOVER;
         this.joinBtn.Name = "joinBtn";
         this.joinBtn.Primary = true;
         this.joinBtn.Size = new System.Drawing.Size(75, 23);
         this.joinBtn.TabIndex = 5;
         this.joinBtn.Text = "Join";
         this.joinBtn.UseVisualStyleBackColor = true;
         // 
         // materialSingleLineTextField1
         // 
         this.materialSingleLineTextField1.Depth = 0;
         this.materialSingleLineTextField1.Hint = "password";
         this.materialSingleLineTextField1.Location = new System.Drawing.Point(12, 121);
         this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
         this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
         this.materialSingleLineTextField1.PasswordChar = '*';
         this.materialSingleLineTextField1.SelectedText = "";
         this.materialSingleLineTextField1.SelectionLength = 0;
         this.materialSingleLineTextField1.SelectionStart = 0;
         this.materialSingleLineTextField1.Size = new System.Drawing.Size(222, 23);
         this.materialSingleLineTextField1.TabIndex = 4;
         this.materialSingleLineTextField1.UseSystemPasswordChar = false;
         // 
         // chatroomNameTextField
         // 
         this.chatroomNameTextField.Depth = 0;
         this.chatroomNameTextField.Hint = "chatroom name";
         this.chatroomNameTextField.Location = new System.Drawing.Point(12, 92);
         this.chatroomNameTextField.MouseState = MaterialSkin.MouseState.HOVER;
         this.chatroomNameTextField.Name = "chatroomNameTextField";
         this.chatroomNameTextField.PasswordChar = '\0';
         this.chatroomNameTextField.SelectedText = "";
         this.chatroomNameTextField.SelectionLength = 0;
         this.chatroomNameTextField.SelectionStart = 0;
         this.chatroomNameTextField.Size = new System.Drawing.Size(222, 23);
         this.chatroomNameTextField.TabIndex = 3;
         this.chatroomNameTextField.UseSystemPasswordChar = false;
         // 
         // SubscribeChatroomForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(246, 222);
         this.Controls.Add(this.joinBtn);
         this.Controls.Add(this.materialSingleLineTextField1);
         this.Controls.Add(this.chatroomNameTextField);
         this.Name = "SubscribeChatroomForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Subscribe to Chatroom";
         this.ResumeLayout(false);

      }

      #endregion

      private MaterialSkin.Controls.MaterialRaisedButton joinBtn;
      private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
      private MaterialSkin.Controls.MaterialSingleLineTextField chatroomNameTextField;
   }
}