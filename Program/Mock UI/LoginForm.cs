﻿using System;
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
using ChatApp.Interfaces;
using ChatApp.Services;
using Newtonsoft.Json;

namespace ChatApp
{
   public partial class LoginForm : Form
   {
      private NetworkStream stream;
      private IUserService userService;

      /// <summary>
      /// Start a UserService using the server connection stream.
      /// </summary>
      /// <param name="stream">Server connection stream</param>
      public LoginForm(NetworkStream stream)
      {
         this.stream = stream;
         userService = new UserService(stream);
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
                    // Open main form with connection
                    if (login())
                    {
                        Hide();
                        var mainForm = new MainForm(stream);
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
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

      /// <summary>
      /// Tries to login to the server, updates the status if unsuccessful. 
      /// </summary>
      /// <returns>true if valid login, false otherwise</returns>
      private bool login()
      { 
         var response = userService.Login(userNameText.Text, passwordText.Text);
         LoginStatus.Text = response.message;
         return response.command == "SUCCESS";
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

      /// <summary>
      /// Take the user back to startup form.
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

      private void LoginForm_Load(object sender, EventArgs e)
      {

      }

      private void LoginStatus_Click(object sender, EventArgs e)
      {

      }
   }
}
