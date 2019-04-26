using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChatApp.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using Mock_UI;
using Mock_UI.Enums;

namespace ChatApp
{
   public partial class MainForm : MaterialForm
   {
      // Message Services
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;
      private MaterialSkinManager materialSkinManager;
      private List<Chatroom> chatroomList;

      /// <summary>
      /// The main application form. Handles chat logic.
      /// </summary>
      /// <param name="stream"></param>
      public MainForm(IServerConnection serverConnection, IMessageService messageService)
      {
         this.serverConnection = serverConnection;
         this.messageService = messageService;
         chatroomList = new List<Chatroom>();
         messageService.SendMessage(new TCPMessage { chatID = -1, command = "ACK", message = "0" });
         InitializeComponent();
         setupTheme();
      }

      private void setupTheme()
      {
         this.MaximizeBox = false;

         materialSkinManager = MaterialSkinManager.Instance;
         materialSkinManager.AddFormToManage(this);

         if (Mock_UI.Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.light))
         {
            setLightTheme();
         }
         else if (Mock_UI.Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.dark))
         {
            setDarkTheme();
         }
      }

      private void setDarkTheme()
      {
         materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
         lightToolStripMenuItem.Checked = false;
         darkToolStripMenuItem.Checked = true;
         chatListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF484848");
         chatListBox.ForeColor = Color.White;
         chatListBox.BorderStyle = BorderStyle.None;
         messageField.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF484848");
         messageField.ForeColor = Color.White;
         messageField.BorderStyle = BorderStyle.None;
         userListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF484848");
         userListBox.ForeColor = Color.White;
         userListBox.BorderStyle = BorderStyle.None;
         chatroomListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF484848");
         chatroomListBox.ForeColor = Color.White;
         chatroomListBox.BorderStyle = BorderStyle.None;
         toolTip.ForeColor = Color.White;
      }

      private void setLightTheme()
      {
         materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         lightToolStripMenuItem.Checked = true;
         darkToolStripMenuItem.Checked = false;
         chatListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFEBEBEB");
         chatListBox.ForeColor = SystemColors.WindowText;
         chatListBox.BorderStyle = BorderStyle.None;
         messageField.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFEBEBEB");
         messageField.ForeColor = SystemColors.WindowText;
         messageField.BorderStyle = BorderStyle.None;
         userListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFEBEBEB");
         userListBox.ForeColor = SystemColors.WindowText;
         userListBox.BorderStyle = BorderStyle.None;
         chatroomListBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFEBEBEB");
         chatroomListBox.ForeColor = SystemColors.WindowText;
         chatroomListBox.BorderStyle = BorderStyle.None;
         toolTip.ForeColor = SystemColors.WindowText;
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
         tcpMessage.chatID = ((Chatroom)(chatroomListBox.SelectedItem)).id;

         EnumMessageStatus status = messageService.SendMessage(tcpMessage);

         if (status == EnumMessageStatus.successful)
            messageField.Clear();

         //messageStatusLabel.Text = EnumExtensions.GetEnumDescription(status);

         setToolTip(EnumExtensions.GetEnumDescription(status));
      }

      /// <summary>
      ///  When the message field text is changed, clear the status label.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void messageField_TextChanged(object sender, EventArgs e)
      {
         toolTip.Text = "";
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
                  case "CHATROOMLIST":
                     //TODO: Parse list and update local list of chatrooms with id and name
                     ParseChatroomList(t);//TODO: Finish this function
                     break;
                  default:
                     Chatroom room = chatroomList.Find(x => x.id == t.chatID);
                     room.messages.Add(t);
                     if(((Chatroom)chatroomListBox.SelectedItem).id == t.chatID)
                     {
                        chatListBox.Items.Add(t.message);
                        chatListBox.SelectedIndex = chatListBox.Items.Count - 1;
                        chatListBox.SelectedIndex = -1;
                     }
                     break;
               }
            }
         }
      }

      private void populateChatListBox(Chatroom room)
      {
         foreach(TCPMessage t in room.messages)
         {
            chatListBox.Items.Add(t.message);
            chatListBox.SelectedIndex = chatListBox.Items.Count - 1;
            chatListBox.SelectedIndex = -1;
         }
      }

      /// <summary>
      /// Parses through a list of all the current chatrooms
      /// </summary>
      /// <param name="message">Message with the chatroom list.</param>
      private void ParseChatroomList(TCPMessage message)
      {
         //TODO: Might want to reset the chatroomlist before or in this function
         string[] idNames = message.message.Split(',');
         if(idNames.Length % 2 == 1)
         {
            for (int i = 0; i < idNames.Length - 1; i += 2)
            {
               Chatroom temp = new Chatroom(int.Parse(idNames[i]), idNames[i + 1]);
               chatroomListBox.Items.Add(temp);
               chatroomList.Add(temp);
            }
         }
         else{}//Bad formating

         chatroomListBox.SetSelected(0, true);
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
            // do nothing on purpose
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
      private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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

      
      private void chatList_MeasureItem(object sender, MeasureItemEventArgs e)
      {
         e.ItemHeight = (int)e.Graphics.MeasureString(chatListBox.Items[e.Index].ToString(), chatListBox.Font, chatListBox.Width).Height;
      }

      private void chatList_DrawItem(object sender, DrawItemEventArgs e)
      {
         e.DrawBackground();
         e.DrawFocusRectangle();
         if(e.Index >= 0)
            e.Graphics.DrawString(chatListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
      }

      /// <summary>
      /// Allow copying a chat message using crtl-c.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chatList_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.Control && e.KeyCode == Keys.C)
         {
            System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
            foreach (object item in chatListBox.SelectedItems)
               copy_buffer.AppendLine(item.ToString());
            if (copy_buffer.Length > 0)
               Clipboard.SetText(copy_buffer.ToString());
         }
      }

      private void setToolTip(String message)
      {
         toolTip.Text = message;
         toolTipTimer.Start();
      }

      private void toolTipTimer_Tick(object sender, EventArgs e)
      {
         toolTip.Text = "";
         toolTipTimer.Stop();
      }

      private void lightToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Mock_UI.Properties.Settings.Default.Theme = EnumExtensions.GetEnumDescription(EnumTheming.light);
         Mock_UI.Properties.Settings.Default.Save();

         setLightTheme();
      }

      private void darkToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Mock_UI.Properties.Settings.Default.Theme = EnumExtensions.GetEnumDescription(EnumTheming.dark);
         Mock_UI.Properties.Settings.Default.Save();

         setDarkTheme();
      }

      private void chatroomListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         chatListBox.Items.Clear();
         populateChatListBox((Chatroom)(chatroomListBox.SelectedItem));
      }
   }
}
