using ChatApp;
using ChatApp.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using Mock_UI.Enums;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mock_UI
{
   public partial class CreateChatroomForm : MaterialForm
   {
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;
      private MaterialSkinManager materialSkinManager;

      /// <summary>
      /// Initializes a new CreateChatroomForm with given ServerConnection and MessageService. Sets up theme.
      /// </summary>
      /// <param name="serverConnection">connection to use</param>
      /// <param name="messageService">message service to use</param>
      public CreateChatroomForm(IServerConnection serverConnection, IMessageService messageService)
      {
         this.serverConnection = serverConnection;
         this.messageService = messageService;
         InitializeComponent();
         setupTheme();
      }

      /// <summary>
      /// Sets up the form theming by creating and initializing a MaterialSkinManager as well as adding it to the form.
      /// Makes the form non resizable, ontop of MainForm, and sets the MaterialSkinManager theme to light/dark according to the user settings.
      /// </summary>
      private void setupTheme()
      {
         this.MaximizeBox = false;
         this.TopMost = true;

         materialSkinManager = MaterialSkinManager.Instance;
         materialSkinManager.AddFormToManage(this);
         if (Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.light))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         }
         else if (Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.dark))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
         }
      }
      
      /// <summary>
      /// Hash the given string using sha1
      /// </summary>
      /// <param name="password">to be hashed</param>
      /// <returns>sha1 hashed string</returns>
      private string hashPassword(string password)
      {
         SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
         byte[] data = Encoding.ASCII.GetBytes(password);
         byte[] sha1data = sha1.ComputeHash(data);

         return new string(Encoding.ASCII.GetChars(sha1data));
      }

      /// <summary>
      /// Try to create a chatroom, if successful then close this form, if not then tell the user as such.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void createBtn_Click(object sender, System.EventArgs e)
      {
         responseLabel.Text = "Creating chatroom...";

         string failed = "EXCEPTION";
         var response = createChatroom();
         if (response.command != failed)
         {
            responseLabel.Text = response.message;
            this.Hide();
         }
         else
            responseLabel.Text = response.message;
      }

      /// <summary>
      /// Try to send a NEW_CHAT message to the server and wait for response.
      /// </summary>
      /// <returns>response message</returns>
      private TCPMessage createChatroom()
      {
         messageService.SendMessage(new TCPMessage { chatID = 0, command = "NEW_CHAT", message = hashPassword(passwordField.Text) + nameField.Text });

         return waitForResponse();
      }

      /// <summary>
      /// Waiting for an exception or confirmation from the server.
      /// </summary>
      /// <returns>response message</returns>
      private TCPMessage waitForResponse()
      {
         while (!messageService.CheckForMessages())
         {
            Thread.Sleep(1000);
         }

         return messageService.ReadInFirstMessage();
      }

      /// <summary>
      /// If enter is pressed in the password field then treat it like pressing the create button.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void passwordField_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            createBtn_Click(this, new EventArgs());
         }
      }
   }
}
