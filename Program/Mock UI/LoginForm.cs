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
using Newtonsoft.Json;

namespace Mock_UI
{
   public partial class LoginForm : Form
   {
      private NetworkStream stream;
      public LoginForm(NetworkStream stream)
      {
         this.stream = stream;
         InitializeComponent();
      }

      /// <summary>
      /// Check to make sure that the username is valid, then try to create a socket ip address and port,
      /// catch exceptions from both. Hash the password and send a login request, server will disconnect you if invalid login.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void connectButton_Click(object sender, EventArgs e)
      {
         if (validUserName(userNameText.Text))
         {
            try
            {
               login();

               /* removed this because we moved connection stuff to startup
               // Detect if client disconnected
               if (socket.Client.Poll(0, SelectMode.SelectRead))
               {
                  byte[] buff = new byte[1];
                  if (socket.Client.Receive(buff, SocketFlags.Peek) == 0)
                  {
                     System.Windows.Forms.MessageBox.Show("Login failed.");
                     return;
                  }
               }
               */

               // Open main form with connection
               this.Hide();
               var form1 = new MainForm(stream);
               form1.FormClosed += (s, args) => this.Close();
               form1.Show();
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
         else
         {
            System.Windows.Forms.MessageBox.Show(EnumExtensions.GetEnumDescription(EnumUserConnectionExceptions.invalidUsername));
         }

      }

      private void login()
      {

         // TODO
         //USE A LOGIN COMMAND, SEND USERNAME AND PASSWORD, SERVER WILL DISCONNECT YOU IF IT IS NOT CORRECT.
         //attempt to login with usernameText.Text and hashed password
         byte[] hashedPassword = hashPassword();

         var newUser = new TCPMessage { chatID = 0, message = userNameText.Text, command = "SETNAME" };
         var msg = JsonConvert.SerializeObject(newUser);
         msg = msg.Length + ":" + msg;
         stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
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
      /// A username is valid if it only contains letters, digits, hyphens, or underscores. 
      /// If it contains any other character it is invalid. Can't be empty.
      /// </summary>
      /// <param name="username"></param>
      /// <returns></returns>
      private Boolean validUserName(String username)
      {
         if (username.Length <= 0)
            return false;

         if (username.All(x => char.IsLetterOrDigit(x) || x == '-' || x == '_'))
         {
            return true;
         }

         return false;
      }

   }
}
