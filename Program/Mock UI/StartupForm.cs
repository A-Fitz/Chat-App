﻿using ChatApp.Services;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChatApp
{
   public partial class StartupForm : Form
   {
      private NetworkStream stream;
      private IMessageService messageService;

      /// <summary>
      /// Sets up connection with the server and handles exceptions.
      /// </summary>
      public StartupForm()
      {
         InitializeComponent();

         try
         {
            TcpClient socket = new TcpClient("127.0.0.1", 12345);
            stream = socket.GetStream(); // will catch exceptions from this
            messageService = new MessageService(stream);

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
      public StartupForm(NetworkStream stream)
      {
         InitializeComponent();
         this.stream = stream;
         messageService = new MessageService(stream);

         loginButton.Enabled = true;
         registerButton.Enabled = true;
      }

      /// <summary>
      /// Closes this form and opens the login form.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void loginButton_Click(object sender, EventArgs e)
      {
         this.Hide();
         var loginForm = new LoginForm(stream);
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
         this.Hide();
         var registerForm = new RegisterForm(stream);
         registerForm.FormClosed += (s, args) => this.Close();
         registerForm.Show();
      }

      /// <summary>
      /// If this form is manually closed then disconnect from the server safely.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
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
