using ChatApp.Interfaces;
using ChatApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
   public partial class RegisterForm : Form
   {
      private string failedLogin = "EXCEPTION";
      private NetworkStream stream;
      private IUserService userService;
      private LoginForm loginForm;

      /// <summary>
      /// Start a new UserService using the server connection stream.
      /// </summary>
      /// <param name="stream">Server connection stream</param>
      public RegisterForm(NetworkStream stream)
      {
         this.stream = stream;
         userService = new UserService(stream);
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
               loginForm = new LoginForm(stream);
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
      /// Hash the password from passwordText using SHA1.
      /// </summary>
      /// <returns>byte array containing hashed password</returns>
      private byte[] hashPassword()
      {
         SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
         byte[] data = Encoding.ASCII.GetBytes(passwordText.Text);
         byte[] sha1data = sha1.ComputeHash(data);

         return sha1data;
      }

      /// <summary>
      /// Take user back to startup form when the back button is clicked.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void backButton_Click(object sender, EventArgs e)
      {
         this.Hide();
         var startupForm = new StartupForm(stream);
         startupForm.FormClosed += (s, args) => this.Close();
         startupForm.Show();
      }
   }
}
