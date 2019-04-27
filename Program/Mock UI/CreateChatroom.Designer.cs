namespace Mock_UI
{
   partial class CreateChatroom
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
         this.chatroomNameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.createBtn = new MaterialSkin.Controls.MaterialRaisedButton();
         this.SuspendLayout();
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
         this.chatroomNameTextField.TabIndex = 0;
         this.chatroomNameTextField.UseSystemPasswordChar = false;
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
         this.materialSingleLineTextField1.TabIndex = 1;
         this.materialSingleLineTextField1.UseSystemPasswordChar = false;
         // 
         // createBtn
         // 
         this.createBtn.Depth = 0;
         this.createBtn.Location = new System.Drawing.Point(82, 164);
         this.createBtn.MouseState = MaterialSkin.MouseState.HOVER;
         this.createBtn.Name = "createBtn";
         this.createBtn.Primary = true;
         this.createBtn.Size = new System.Drawing.Size(75, 23);
         this.createBtn.TabIndex = 2;
         this.createBtn.Text = "Create";
         this.createBtn.UseVisualStyleBackColor = true;
         // 
         // CreateChatroom
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(246, 222);
         this.Controls.Add(this.createBtn);
         this.Controls.Add(this.materialSingleLineTextField1);
         this.Controls.Add(this.chatroomNameTextField);
         this.Name = "CreateChatroom";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Create Chatroom";
         this.ResumeLayout(false);

      }

      #endregion

      private MaterialSkin.Controls.MaterialSingleLineTextField chatroomNameTextField;
      private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
      private MaterialSkin.Controls.MaterialRaisedButton createBtn;
   }
}