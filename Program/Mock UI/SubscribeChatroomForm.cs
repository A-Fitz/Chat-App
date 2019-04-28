﻿using ChatApp;
using ChatApp.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using Mock_UI.Enums;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Mock_UI
{
   public partial class SubscribeChatroomForm : MaterialForm
   {
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;
      private MaterialSkinManager materialSkinManager;

      /// <summary>
      /// Initializes a new SubscribeChatroomForm with given ServerConnection and MessageService. Sets up theme.
      /// </summary>
      /// <param name="serverConnection">connection to use</param>
      /// <param name="messageService">message service to use</param>
      public SubscribeChatroomForm(IServerConnection serverConnection, IMessageService messageService)
      {
         this.serverConnection = serverConnection;
         this.messageService = messageService;
         InitializeComponent();
         setupTheme();
      }

      /// <summary>
      /// Sets up the form theming by creating and initializing a MaterialSkinManager as well as adding it to the form.
      /// Makes the form non resizable, ontop of MainForm, and sets the MaterialSkinManager theme to light/dark according to the user settings.
      /// </summary>
      private void setupTheme()
      {
         this.MaximizeBox = false;
         this.TopMost = true;

         materialSkinManager = MaterialSkinManager.Instance;
         materialSkinManager.AddFormToManage(this);
         if (Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.light))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         }
         else if (Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.dark))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
         }
      }

      private string hashPassword(string password)
      {
         SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
         byte[] data = Encoding.ASCII.GetBytes(password);
         byte[] sha1data = sha1.ComputeHash(data);

         return new string(Encoding.ASCII.GetChars(sha1data));
      }

      private TCPMessage joinChatroom()
      {
         messageService.SendMessage(new TCPMessage { chatID = 0, command = "JOIN_CHAT", message = hashPassword(passwordField.Text) + chatroomIDField.Text });

         return waitForResponse();
      }

      private TCPMessage waitForResponse()
      {
         while (!messageService.CheckForMessages())
         {
            Thread.Sleep(1000);
         }

         return messageService.ReadInFirstMessage();
      }

      private void joinBtn_Click(object sender, System.EventArgs e)
      {
         string failed = "EXCEPTION";
         var response = joinChatroom();
         if (response.command != failed)
         {
            responseLabel.Text = response.message;
            this.Hide();
         }
         else
            responseLabel.Text = response.message;
      }
   }
}
