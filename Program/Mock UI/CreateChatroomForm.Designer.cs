namespace Mock_UI
{
   partial class CreateChatroomForm
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
         this.nameField = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.passwordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
         this.createBtn = new MaterialSkin.Controls.MaterialRaisedButton();
         this.responseLabel = new MaterialSkin.Controls.MaterialLabel();
         this.SuspendLayout();
         // 
         // nameField
         // 
         this.nameField.Depth = 0;
         this.nameField.Hint = "chatroom name";
         this.nameField.Location = new System.Drawing.Point(12, 107);
         this.nameField.MouseState = MaterialSkin.MouseState.HOVER;
         this.nameField.Name = "nameField";
         this.nameField.PasswordChar = '\0';
         this.nameField.SelectedText = "";
         this.nameField.SelectionLength = 0;
         this.nameField.SelectionStart = 0;
         this.nameField.Size = new System.Drawing.Size(222, 23);
         this.nameField.TabIndex = 0;
         this.nameField.UseSystemPasswordChar = false;
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
         this.passwordField.TabIndex = 1;
         this.passwordField.UseSystemPasswordChar = false;
         this.passwordField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordField_KeyDown);
         // 
         // createBtn
         // 
         this.createBtn.Depth = 0;
         this.createBtn.Location = new System.Drawing.Point(82, 173);
         this.createBtn.MouseState = MaterialSkin.MouseState.HOVER;
         this.createBtn.Name = "createBtn";
         this.createBtn.Primary = true;
         this.createBtn.Size = new System.Drawing.Size(75, 23);
         this.createBtn.TabIndex = 2;
         this.createBtn.Text = "Create";
         this.createBtn.UseVisualStyleBackColor = true;
         this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
         // 
         // responseLabel
         // 
         this.responseLabel.AutoSize = true;
         this.responseLabel.Depth = 0;
         this.responseLabel.Font = new System.Drawing.Font("Roboto", 11F);
         this.responseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.responseLabel.Location = new System.Drawing.Point(12, 74);
         this.responseLabel.MouseState = MaterialSkin.MouseState.HOVER;
         this.responseLabel.Name = "responseLabel";
         this.responseLabel.Size = new System.Drawing.Size(0, 19);
         this.responseLabel.TabIndex = 3;
         // 
         // CreateChatroomForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(246, 222);
         this.Controls.Add(this.responseLabel);
         this.Controls.Add(this.createBtn);
         this.Controls.Add(this.passwordField);
         this.Controls.Add(this.nameField);
         this.Name = "CreateChatroomForm";
         this.Sizable = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Create Chatroom";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private MaterialSkin.Controls.MaterialSingleLineTextField nameField;
      private MaterialSkin.Controls.MaterialSingleLineTextField passwordField;
      private MaterialSkin.Controls.MaterialRaisedButton createBtn;
      private MaterialSkin.Controls.MaterialLabel responseLabel;
   }
}