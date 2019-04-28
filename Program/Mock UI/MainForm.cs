using ChatApp.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using Mock_UI;
using Mock_UI.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChatApp
{
   public partial class MainForm : MaterialForm
   {
      // Message Services
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;
      private MaterialSkinManager materialSkinManager;
      private List<Chatroom> chatroomList;
      private object selectedChatroomInListBox;
      private CommandManager commandManager = new CommandManager();

      /// <summary>
      /// The main application form. Handles chat logic. Follows theming settings.
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

      /// <summary>
      /// Initializes the MaterialSkinManager and adds it to the form. Sets the UI theme based off of the currently
      /// saved setting.
      /// </summary>
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

      /// <summary>
      /// Sets the UI properties for the dark theme.
      /// </summary>
      private void setDarkTheme()
      {
         // Default MaterialSkinManager dark theme
         materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
         // Menu strip check icon for dark theme
         lightToolStripMenuItem.Checked = false;
         darkToolStripMenuItem.Checked = true;
         // The chat message list box, message entry field, user list box, and chatroom list box have
         //    a dark grey background, white text, and no border
         chatListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.dark_grey);
         chatListBox.ForeColor = Color.White;
         chatListBox.BorderStyle = BorderStyle.None;
         messageField.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.dark_grey);
         messageField.ForeColor = Color.White;
         messageField.BorderStyle = BorderStyle.None;
         userListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.dark_grey);
         userListBox.ForeColor = Color.White;
         userListBox.BorderStyle = BorderStyle.None;
         chatroomListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.dark_grey);
         chatroomListBox.ForeColor = Color.White;
         chatroomListBox.BorderStyle = BorderStyle.None;
         // The send-message response label has white text
         messageResponse.ForeColor = Color.White;
      }

      /// <summary>
      /// Sets the UI properties for the light theme.
      /// </summary>
      private void setLightTheme()
      {
         // Default MaterialSkinManager light theme
         materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         // Menu strip check icon for light theme
         lightToolStripMenuItem.Checked = true;
         darkToolStripMenuItem.Checked = false;
         // The chat message list box, message entry field, user list box, and chatroom list box have
         //    a light grey background, black text, and no border
         chatListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.light_grey);
         chatListBox.ForeColor = Color.Black;
         chatListBox.BorderStyle = BorderStyle.None;
         messageField.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.light_grey);
         messageField.ForeColor = Color.Black;
         messageField.BorderStyle = BorderStyle.None;
         userListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.light_grey);
         userListBox.ForeColor = SystemColors.WindowText;
         userListBox.BorderStyle = BorderStyle.None;
         chatroomListBox.BackColor = System.Drawing.ColorTranslator.FromHtml(Mock_UI.Properties.Settings.Default.light_grey);
         chatroomListBox.ForeColor = Color.Black;
         chatroomListBox.BorderStyle = BorderStyle.None;
         // The send-message response label has black text
         messageResponse.ForeColor = Color.Black;
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

         // send chatroom message
         if (chatroomListBox.SelectedIndex >= 0)
            tcpMessage.chatID = ((Chatroom)(chatroomListBox.SelectedItem)).id;
         else if (userListBox.SelectedIndex >= 0) // TODO send direct message
         {
            //String temp = "000" + (userListBox.SelectedItem.ToString()).to;
         }

         EnumMessageStatus status = messageService.SendMessage(tcpMessage);

         if (status == EnumMessageStatus.successful)
            messageField.Clear();

         setResponseMessage(EnumExtensions.GetEnumDescription(status));
      }

      /// <summary>
      ///  When the message field text is changed, clear the status label.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void messageField_TextChanged(object sender, EventArgs e)
      {
         messageResponse.Text = "";
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
                     ParseChatroomList(t);
                     break;
                  default:
                     Chatroom room = chatroomList.Find(x => x.id == t.chatID);
                     room.messages.Add(t);
                     // TODO add notification system if new messages are for not currently selected chatroom
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

      

      /// <summary>
      /// Parses through a list of all the current chatrooms
      /// </summary>
      /// <param name="message">Message with the chatroom list.</param>
      private void ParseChatroomList(TCPMessage message)
      {
         string[] idNames = message.message.Split(',');
         if(idNames.Length % 2 == 1)
         {
            for (int i = 0; i < idNames.Length - 1; i += 2)
            {
               // don't add already existing chatrooms
               if(chatroomList.Any(x => x.id == int.Parse(idNames[i])))
               {
                  continue;
               }
               Chatroom temp = new Chatroom(int.Parse(idNames[i]), idNames[i + 1]);
               chatroomListBox.Items.Add(temp);
               chatroomList.Add(temp);
            }
         }
         else{}//Bad formating

         chatroomListBox.SetSelected(0, true);
         selectedChatroomInListBox = chatroomListBox.SelectedItem;
         undoChatroomChangeBtn.Enabled = false;
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


      /// <summary>
      /// Used for wrapping long chat messages to new lines.
      /// https://stackoverflow.com/questions/17613613/winforms-dotnet-listbox-items-to-word-wrap-if-content-string-width-is-bigger-tha
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chatList_MeasureItem(object sender, MeasureItemEventArgs e)
      {
         e.ItemHeight = (int)e.Graphics.MeasureString(chatListBox.Items[e.Index].ToString(), chatListBox.Font, chatListBox.Width).Height;
      }

      /// <summary>
      /// Used for wrapping long chat messages to new lines.
      /// https://stackoverflow.com/questions/17613613/winforms-dotnet-listbox-items-to-word-wrap-if-content-string-width-is-bigger-tha
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chatList_DrawItem(object sender, DrawItemEventArgs e)
      {
         e.DrawBackground();
         e.DrawFocusRectangle();
         if(e.Index >= 0)
            e.Graphics.DrawString(chatListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
      }

      /// <summary>
      /// Allow copying a chat message using crtl-c.
      /// https://stackoverflow.com/questions/51306469/how-to-allow-the-user-to-copy-items-from-listbox-and-paste-outside-of-windows-fo
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

      /// <summary>
      /// Sets the send-message response label to a specified string and start the timer which will remove the text.
      /// </summary>
      /// <param name="message">The response message to display</param>
      private void setResponseMessage(String message)
      {
         messageResponse.Text = message;
         messageResponseTimer.Start();
      }

      /// <summary>
      /// After the send-message response timer has been displayed for an amount of time, erase it and stop the timer.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void messageResponseTimer_Tick(object sender, EventArgs e)
      {
         messageResponse.Text = "";
         messageResponseTimer.Stop();
      }

      /// <summary>
      /// When the menu strip option for the light theme is clicked then change and save the theme setting and
      /// change the the light theme.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void lightToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Mock_UI.Properties.Settings.Default.Theme = EnumExtensions.GetEnumDescription(EnumTheming.light);
         Mock_UI.Properties.Settings.Default.Save();

         setLightTheme();
      }

      /// <summary>
      /// When the menu strip option for the dark theme is clicked then change and save the theme setting and
      /// change the the dark theme.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void darkToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Mock_UI.Properties.Settings.Default.Theme = EnumExtensions.GetEnumDescription(EnumTheming.dark);
         Mock_UI.Properties.Settings.Default.Save();

         setDarkTheme();
      }

      /// <summary>
      /// When a new chatroom is clicked in the chatroom list box then execute the ChangeChatroomCommand.
      /// Allows for the use of an undo button to go back to the last chatroom.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chatroomListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         commandManager.ExecuteCommand(new ChangeChatroomCommand(chatroomListBox, chatListBox, selectedChatroomInListBox));

         selectedChatroomInListBox = chatroomListBox.SelectedItem;

         undoChatroomChangeBtn.Enabled = true;
      }

      /// <summary>
      /// When the undo button below the chatroom list is clicked then go back to the previously selected chatroom.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void undoChatroomChangeBtn_Click(object sender, EventArgs e)
      {
         commandManager.Undo();
      }

      /// <summary>
      /// Open a new CreateChatroomForm dialog.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void newChatroomBtn_Click(object sender, EventArgs e)
      {
         var createChatroomForm = new CreateChatroomForm(serverConnection, messageService);
         createChatroomForm.Show();
      }

      /// <summary>
      /// Opens a new SubscribeChatroomForm dialog.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void subscribeChatroomBtn_Click(object sender, EventArgs e)
      {
         var subscribeChatroomForm = new SubscribeChatroomForm(serverConnection, messageService);
         subscribeChatroomForm.Show();
      }
   }
}
