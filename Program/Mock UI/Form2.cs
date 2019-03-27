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
   public partial class Form2 : Form
   {
      public Form2()
      {
         InitializeComponent();
         portNumeric.Controls[0].Visible = false; // remove the arrows from the port numeric updown
      }

      /// <summary>
      /// Check to make sure that the username is valid, then try to create a socket with the given ip address and port,
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
               TcpClient socket = new TcpClient(ipAddressText.Text, Decimal.ToInt32(portNumeric.Value));
               var newConnection = setupNewConnection(socket); // will catch exceptions from this

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
               this.Hide();
               var form1 = new Form1(newConnection);
               form1.FormClosed += (s, args) => this.Close();
               form1.Show();
            }
            catch (SocketException)
            {
               System.Windows.Forms.MessageBox.Show("You provided an incorect IP address or port.");
            }
            catch (ArgumentOutOfRangeException)
            {
               System.Windows.Forms.MessageBox.Show("You provided an incorect IP address or port.");
            }
            catch (ArgumentNullException)
            {
               System.Windows.Forms.MessageBox.Show("You provided an incorect IP address or port.");
            }
            catch (Exception)
            {
               System.Windows.Forms.MessageBox.Show("Unknown exception occured.");
            }


         }
         else
         {
            System.Windows.Forms.MessageBox.Show("Please Enter Valid Username.");
         }

      }

      private NetworkStream setupNewConnection(TcpClient socket)
      {
         NetworkStream stream = socket.GetStream();

         // TODO
         //USE A LOGIN COMMAND, SEND USERNAME AND PASSWORD, SERVER WILL DISCONNECT YOU IF IT IS NOT CORRECT.
         //attempt to login with usernameText.Text and sha1data (password)
         var sha1 = new SHA1CryptoServiceProvider();
         var data = Encoding.ASCII.GetBytes(passwordText.Text);
         var sha1data = sha1.ComputeHash(data);

         var newUser = new TCPMessage { chatID = 0, message = userNameText.Text, command = "SETNAME" };
         var msg = JsonConvert.SerializeObject(newUser);
         msg = msg.Length + ":" + msg;
         stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);

         return stream;
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
