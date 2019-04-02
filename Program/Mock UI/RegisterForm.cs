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

namespace Mock_UI
{
   public partial class RegisterForm : Form
   {
      private NetworkStream stream;

      public RegisterForm(NetworkStream stream)
      {
         this.stream = stream;
         InitializeComponent();
      }

      private void registerButton_Click(object sender, EventArgs e)
      {
         if (!isUsernameAvailable())
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.takenUsername));
         }
         else if (!isUsernameValid())
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidUsername));
         }
         else if (!isPasswordValid())
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidPassword));
         }
         else
         {
            //register
         }
      }

      private void userNameText_Leave(object sender, EventArgs e)
      {
         if(!isUsernameAvailable())
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.takenUsername));
         }
         else if(!isUsernameValid())
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidUsername));
         }
         else
         {
            registerButton.Enabled = true;
         }
      }

      private void userNameText_TextChanged(object sender, EventArgs e)
      {
         // lock button
         registerButton.Enabled = false;
      }

      private Boolean isPasswordValid()
      {
         return passwordText.Text.Length >= 4;
      }

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
      /// Checks if the username is available. Connects 
      /// </summary>
      /// <returns></returns>
      private Boolean isUsernameAvailable()
      {
         // TODO do database stuff
         return true;
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
      /// Take user back to startup form.
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
