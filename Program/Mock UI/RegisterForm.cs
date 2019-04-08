using ChatApp.Interfaces;
using ChatApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ChatApp
{
   public partial class RegisterForm : Form
   {
      private string failedLogin = "EXCEPTION";
      private readonly IServerConnection serverConnection;
      private readonly IUserService userService;
      private readonly IMessageService messageService;
      private LoginForm loginForm;

      /// <summary>
      /// Start a new UserService using the server connection stream.
      /// </summary>
      /// <param name="stream">Server connection stream</param>
      public RegisterForm(IServerConnection serverConnection, IMessageService messageService)
      {
         this.messageService = messageService;
         this.serverConnection = serverConnection;
         userService = new UserService(serverConnection, messageService);
         InitializeComponent();
      }

      /// <summary>
      /// Attempt to register to user while displaying correct status messages. If registration successful, open the login form.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void registerButton_Click(object sender, EventArgs e)
      {
         registrationStatus.Text = "Registering user...";
         if (!isUsernameValid())
         {
            registrationStatus.Text = EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidUsername);
         }
         else if (!isPasswordValid())
         {
            registrationStatus.Text = EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidPassword);
         }
         else
         {
            var response = userService.RegisterUser(userNameText.Text, passwordText.Text); // try to register user, get response
            if (response.command != failedLogin)
            {
               // if successful registration, go to login form
               registrationStatus.Text = response.message;
               Hide();
               loginForm = new LoginForm(serverConnection, messageService);
               loginForm.FormClosed += (s, args) => this.Close();
               loginForm.Show();
            }
            else
               registrationStatus.Text = response.message;
         }
      }

      /// <summary>
      /// When the user leaves the username text field, check if their input is valid. If it is not, 
      /// change the registration status. If it is, unlock the register button.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void userNameText_Leave(object sender, EventArgs e)
      {
         if(!isUsernameValid())
         {
            registrationStatus.Text = EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidUsername);
         }
         else
         {
            registerButton.Enabled = true;
         }
      }

      /// <summary>
      /// Lock the register button everytime the username text field is changed so we don't try toi register an invalid username.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void userNameText_TextChanged(object sender, EventArgs e)
      {
         // lock button
         registerButton.Enabled = false;
      }

      /// <summary>
      /// Check if the password text field contains a password that is at least 4 characters long.
      /// </summary>
      /// <returns>true if valid password, false otherwise</returns>
      private Boolean isPasswordValid()
      {
         return passwordText.Text.Length >= 4;
      }

      /// <summary>
      /// Check if the username text field contains a username 
      /// </summary>
      /// <returns>true if valid username, false otherwise</returns>
      private Boolean isUsernameValid()
      {
         if (userNameText.Text.Length <= 0)
            return false;

         if (userNameText.Text.All(x => char.IsLetterOrDigit(x) || x == '-' || x == '_'))
         {
            return true;
         }

         return false;
      }

      /// <summary>
      /// Take user back to startup form when the back button is clicked.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void backButton_Click(object sender, EventArgs e)
      {
         this.Hide();
         var startupForm = new StartupForm(serverConnection, messageService);
         startupForm.FormClosed += (s, args) => this.Close();
         startupForm.Show();
      }
   }
}
