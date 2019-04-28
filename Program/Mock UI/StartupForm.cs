using ChatApp.Interfaces;
using ChatApp.Services;
using MaterialSkin;
using MaterialSkin.Controls;
using Mock_UI.Enums;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatApp
{
   public partial class StartupForm : MaterialForm
   {
      private NetworkStream stream;
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;

      /// <summary>
      /// Sets up connection with the server and handles exceptions.
      /// </summary>
      public StartupForm()
      {
         InitializeComponent();
         setupTheme();

         try
         {
            TcpClient socket = new TcpClient("127.0.0.1", 12345);
            stream = socket.GetStream(); // will catch exceptions from this
            serverConnection = new ServerConnection(stream);
            messageService = new MessageService(serverConnection);

            // Unlock the login/register buttons only if successfully connected to the server.
            loginButton.Enabled = true;
            registerButton.Enabled = true;
         }
         catch (SocketException)
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.incorrectIP));
         }
         catch (ArgumentOutOfRangeException)
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.incorrectIP));
         }
         catch (ArgumentNullException)
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.incorrectIP));
         }
         catch (Exception)
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.unknown));
         }
      }

      /// <summary>
      /// Constructor called when a connection to the server has already been made. Uses that connection.
      /// </summary>
      /// <param name="stream">Previous server connection stream</param>
      public StartupForm(IServerConnection serverConnection, IMessageService messageService)
      {
         InitializeComponent();
         this.serverConnection = serverConnection;
         this.messageService = messageService;
         loginButton.Enabled = true;
         registerButton.Enabled = true;
      }

      /// <summary>
      /// Sets up the form theming by creating and initializing a MaterialSkinManager as well as adding it to the form.
      /// Makes the form non resizable and sets the MaterialSkinManager theme to light/dark according to the user settings.
      /// </summary>
      private void setupTheme()
      {
         this.MaximizeBox = false;

         MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
         materialSkinManager.AddFormToManage(this);
         if (Mock_UI.Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.light))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         }
         else if (Mock_UI.Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.dark))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
         }
      }

      /// <summary>
      /// Closes this form and opens the login form.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void loginButton_Click(object sender, EventArgs e)
      {
         this.Hide();
         var loginForm = new LoginForm(serverConnection, messageService);
         loginForm.FormClosed += (s, args) => this.Close();
         loginForm.Show();
      }

      /// <summary>
      /// Closes this form and opens the register form.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void registerButton_Click(object sender, EventArgs e)
      {
         Hide();
         var registerForm = new RegisterForm(serverConnection, messageService);
         registerForm.FormClosed += (s, args) => Close();
         registerForm.Show();
      }
   }
}
