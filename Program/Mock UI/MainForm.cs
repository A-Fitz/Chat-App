using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChatApp.Interfaces;

namespace ChatApp
{
   public partial class MainForm : Form
   {
      // Message Services
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;

      /// <summary>
      /// The main application form. Handles chat logic.
      /// </summary>
      /// <param name="stream"></param>
      public MainForm(IServerConnection serverConnection, IMessageService messageService)
      {
         this.serverConnection = serverConnection;
         this.messageService = messageService;
         messageService.SendMessage(new TCPMessage { chatID = -1, command = "ACK", message = "0" });
         InitializeComponent();
      }

      /// <summary>
      ///  When the send buttton is clicked: make a new TCPMessage and add the inputed text into it, try to send it
      ///  and get the status, set the status label, clear the message field if successful, and set the status label.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void sendButton_Click(object sender, EventArgs e)
      {
         TCPMessage tcpMessage = new TCPMessage();
         tcpMessage.message = messageField.Text;
         tcpMessage.chatID = 0;

         EnumMessageStatus status = messageService.SendMessage(tcpMessage);

         if (status == EnumMessageStatus.successful)
            messageField.Clear();

         messageStatusLabel.Text = EnumExtensions.GetEnumDescription(status);
      }

      /// <summary>
      ///  When the message field text is changed, clear the status label.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void messageField_TextChanged(object sender, EventArgs e)
      {
         messageStatusLabel.Text = "";
      }

      /// <summary>
      ///  For each tick of the readMessagesTimer (10s currently), check for new messages, check for commands, and add real messages to the chatList.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void readMessagesTimer_Tick(object sender, EventArgs e)
      {

         if (messageService.CheckForMessages())
         {
            IList<TCPMessage> messageList = messageService.GetMessages();
            foreach (TCPMessage t in messageList)
            {
               // handle commands
               switch (t.command)
               {
                  case "CLOSING":
                     MessageBox.Show("SERVER IS CLOSING. YOUR MESSAGES WILL NOT SEND. GOODBYE.");
                     return;
                  case "CLIENTLIST":
                     userListBox.Items.Clear();
                     foreach (string str in t.message.Split(','))
                     {
                        if(str != "")
                           userListBox.Items.Add(str);
                     }
                     break;
                  default:
                     chatList.Items.Add(t.message);
                     break;
               }
               
            }
         }
      }

      /// <summary>
      /// When shift+enter is pressed in the messageField do nothing (adds new line). When only enter clicked send the message and supress the newline.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void messageField_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter && e.Shift)
         {
            // do nothing
         }
         else if (e.KeyCode == Keys.Enter)
         {
            sendButton_Click(sender, e);
            e.SuppressKeyPress = true;
         }
      }

      /// <summary>
      /// Disconnect correctly by sending a CLOSE message to the server.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_FormClosed(object sender, FormClosedEventArgs e)
      {
         TCPMessage tcpMessage = new TCPMessage();
         tcpMessage.chatID = 0;
         tcpMessage.command = "CLOSE";
         tcpMessage.message = "0";
         messageService.SendMessage(tcpMessage);
      }

      /// <summary>
      /// Sign out of the user account and return to the startup form when the signout button is clicked.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         TCPMessage tcpMessage = new TCPMessage();
         tcpMessage.chatID = 0;
         tcpMessage.command = "CLOSE";
         tcpMessage.message = "0";
         messageService.SendMessage(tcpMessage);

         this.Hide();
         var startupForm = new StartupForm();
         startupForm.FormClosed += (s, args) => this.Close();
         startupForm.Show();
      }
   }
}
