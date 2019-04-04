using ChatApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
   public partial class StartupForm : Form
   {
      private NetworkStream stream;
      private IMessageService messageService;
      public StartupForm()
      {
         InitializeComponent();

         try
         {
            TcpClient socket = new TcpClient("127.0.0.1", 12345);
            stream = socket.GetStream(); // will catch exceptions from this
            messageService = new MessageService(stream);
            /* TODO not sure what to do with this
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

      public StartupForm(NetworkStream stream)
      {
         InitializeComponent();
         this.stream = stream;
         messageService = new MessageService(stream);

         loginButton.Enabled = true;
         registerButton.Enabled = true;
      }

      private void loginButton_Click(object sender, EventArgs e)
      {
         this.Hide();
         var loginForm = new LoginForm(stream);
         loginForm.FormClosed += (s, args) => this.Close();
         loginForm.Show();
      }

      private void registerButton_Click(object sender, EventArgs e)
      {
         this.Hide();
         var registerForm = new RegisterForm(stream);
         registerForm.FormClosed += (s, args) => this.Close();
         registerForm.Show();
      }

      private void StartupForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         // TODO do stuff so this doesn't break if the server is disconnected
         TCPMessage tcpMessage = new TCPMessage();
         tcpMessage.chatID = 0;
         tcpMessage.command = "CLOSE";
         tcpMessage.message = "0";
         messageService.SendMessage(tcpMessage);
      }
   }
}
