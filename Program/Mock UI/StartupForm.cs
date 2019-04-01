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

namespace Mock_UI
{
   public partial class StartupForm : Form
   {
      private NetworkStream stream;
      public StartupForm()
      {
         InitializeComponent();

         try
         {
            TcpClient socket = new TcpClient("127.0.0.1", 12345);
            stream = socket.GetStream(); // will catch exceptions from this

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
   }
}
