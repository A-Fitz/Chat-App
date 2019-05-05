//
//Author(s):
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server
{
   public class ClientConnection : IObserver<Message>
   {
      private static int USERNAME_MAX = 20;
      private NetworkStream networkStream;
      public string username { get; set; } = "";
      public int userID { get; set; } = -1;
      private static int numClients = 0;
      private ChatroomList chatroomList;
      public static List<ClientConnection> clients { get; set; } = new List<ClientConnection>();
      private List<ChatroomLogic> chatrooms = new List<ChatroomLogic>();
      private MessageService messageService;

      /// <summary>
      /// Constructor that requires a network stream to listen to and a chatroom list.
      /// </summary>
      /// <param name="ns"></param>
      /// <param name="chatroomList"></param>
      public ClientConnection(NetworkStream ns, ChatroomList chatroomList)
      {
         this.networkStream = ns;
         this.chatroomList = chatroomList;
         messageService = new MessageService(ns);
      }

      /// <summary>
      /// Cleans up the stream.
      /// This method is not reasonably testable. It would validate NetworkStream.
      /// </summary>
      public void disconnect()
      {
         networkStream.Dispose();
         networkStream.Close();
      }

      /// <summary>
      /// Subscribes to a chat. Any new information to the ChatroomLogic that
      /// this object is subsribed to will come through the OnNext() function.
      /// </summary>
      /// <param name="crl"></param>
      public void subsribeToChat(ChatroomLogic crl)
      {
         crl.Subscribe(this);
         chatrooms.Add(crl);
      }

      /// <summary>
      /// Starts the ClientConnection with a new thread.
      /// </summary>
      public void StartAsync()
      {
         Thread clientThread = new Thread(getMessages);

         clientThread.Start();
         lock (clients)
         {
            clients.Add(this);
         }
      }

      /// <summary>
      /// Main client loop that takes in data and does certain operations based
      /// on the command.
      /// </summary>
      private void getMessages()
      {
         try
         {
            if (!Login())
               throw new Exception("Login failed. User disconnected.");

            Console.WriteLine(username + " has successfully logged in.");
            LoadClientData();
            //TODO Make sure client is not recieving messages before login
            while (true)
            {
               Message incomingMsg = messageService.GetMessage();

               if (incomingMsg == null)
                  return;
               switch (incomingMsg.command)
               {
                  case "SEND":
                     incomingMsg.message = DateTime.Now.ToString() + " : " + username + " : " + incomingMsg.message;
                     ChatroomLogic sendChatroom = chatroomList.idToChatroom(incomingMsg.chatID);
                     if (sendChatroom != null && sendChatroom.RegisteredUsers.Contains(userID))
                        chatroomList.update(incomingMsg, userID);
                     else
                        Console.WriteLine("Bad SEND message chatID");
                     break;
                  case "NEW_CHAT":
                     //message = password for chatroom
                     //chatID = wether it is a private room. 1 = direct message room, 0 = normal password protected room
                     ChatroomLogic tempChatroom = new ChatroomLogic();
                     string chatname = incomingMsg.message.Substring(20, incomingMsg.message.Length - 20);
                     string hashword = incomingMsg.message.Substring(0, 20);
                     if (ChatroomList.chatroomServices.CreateChatroom(chatname, tempChatroom.chatroomID, this.userID, hashword, incomingMsg.chatID))
                     {

                        chatroomList.addChat(tempChatroom);
                        tempChatroom.name = chatname;
                        tempChatroom.Subscribe(this);
                        tempChatroom.RegisteredUsers.Add(this.userID);
                        messageService.SendMessage(new Message { chatID = -1, command = "ACK", message = "Chatroom has been created" });
                        SendChatroomList();
                        SendChatHistory(tempChatroom.chatroomID);
                     }
                     else
                     {
                        messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = "Chatroom name already taken" });
                     }

                     break;
                  case "JOIN_CHAT"://and like the video down below
                     string hashword2 = incomingMsg.message.Substring(0, 20);
                     int id = -1;

                     if (int.TryParse(incomingMsg.message.Substring(20, incomingMsg.message.Length - 20), out id))
                     {
                        ChatroomLogic tempChatroom2 = chatroomList.idToChatroom(id);
                        if (tempChatroom2 != null)
                        {
                           //TODO: Check that the password matches the chatrooms password and break out if it is incorrect
                           if (ChatroomList.chatroomServices.AddUser(tempChatroom2.chatroomID, this.userID, hashword2))
                           {
                              tempChatroom2.Subscribe(this);
                              tempChatroom2.RegisteredUsers.Add(this.userID);
                              messageService.SendMessage(new Message { chatID = -1, command = "ACK", message = "Chatroom login succeded" });
                              SendChatroomList();
                              SendChatHistory(tempChatroom2.chatroomID);
                           }
                           else
                           {
                              messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = "Chatroom login failed" });
                              break;
                           }
                        }
                     }
                     else
                        messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = "Bad chatroom id" });

                     break;
                  case "CLOSE":
                     disconnect();
                     clients.Remove(this);
                     sendClientList();
                     Console.Out.WriteLine((username == "" ? "Someone disconected." : username + " disconnected."));
                     return;
                  default:
                     Console.WriteLine("Incorrect Command: Message = " + incomingMsg.chatID + " : " + incomingMsg.command + " : " + incomingMsg.message);
                     break;
               }

            }
         }
         catch (Exception e)
         {
            disconnect();
            clients.Remove(this);
            sendClientList();
            Console.Out.WriteLine((username == "" ? "Someone disconected." : username + " disconnected."));
         }
         finally
         {
            //TODO: Thread is being killed, clean up
         }
      }

      /// <summary>
      /// This will be run imediately following a successful login to do
      /// any startup processes required for the client to run.
      /// </summary>
      private void LoadClientData()
      {
         bool ack = false;
         while (!ack)
            ack = (messageService.GetMessage().command == "ACK");
         //TODO LATER: Request data from SQL server on this client and send messages to

         //this client's OnNext() function.
         subsribeToChat(chatroomList.idToChatroom(0));
         subsribeToChat(chatroomList.idToChatroom(1));
         chatroomList.idToChatroom(0).RegisteredUsers.Add(this.userID);
         chatroomList.idToChatroom(1).RegisteredUsers.Add(this.userID);
         ChatroomList.chatroomServices.AddUser(0, userID, "pass");
         ChatroomList.chatroomServices.AddUser(1, userID, "pass");
         SendChatroomList();
         foreach (ChatroomLogic chatroom in chatroomList.chatrooms)
         {
            if (chatroom.RegisteredUsers.Contains(userID))
            {
               chatroom.Subscribe(this);
               DataTable messages = ChatroomList.chatroomServices.ChatHistory(chatroom.chatroomID);
               foreach (DataRow message in messages.Rows)
                  OnNext(new Message { chatID = chatroom.chatroomID, command = "", message = message["message"].ToString() });
            }
         }

         sendClientList();

      }


      private void SendChatHistory(int chatID)
      {
         DataTable messages = ChatroomList.chatroomServices.ChatHistory(chatID);
         foreach (DataRow message in messages.Rows)
            OnNext(new Message { chatID = chatID, command = "", message = message["message"].ToString() });
      }


      /// <summary>
      /// Handles the login logic, returns false if there was an error
      /// </summary>
      /// <returns>True if successful. False otherwise.</returns>
      private bool Login()
      {
         try
         {
            UserService userService = new UserService();
            while (true)
            {
               Message a = messageService.GetMessage();

               if (a == null)
                  return false;
               string[] usernamePassword = ParseRegisterMessage(a.message);
               switch (a.command)
               {

                  case "REGISTER":
                     if (userService.CheckUsername(usernamePassword[0]))
                     {
                        if (!userService.RegisterUser(usernamePassword[0], usernamePassword[1]))
                           messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = "Login failed" });
                     }
                     else
                     {
                        messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = usernamePassword[0] + " is taken." });
                     }
                     messageService.SendMessage(new Message { chatID = -1, command = "SUCCESS", message = "Registration successful!" });
                     break;
                  case "LOGIN":
                     if (isLoggedIn(usernamePassword[0]))
                     {
                        messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = usernamePassword[0] + " is already logged in." });
                     }
                     else if (0 <= (userID = userService.VerifyLogin(usernamePassword[0], usernamePassword[1])))//
                     {
                        username = usernamePassword[0];
                        Thread.CurrentThread.Name = username;
                        messageService.SendMessage(new Message { chatID = -1, command = "SUCCESS", message = "Login successful!" });
                        return true;
                     }
                     else
                        messageService.SendMessage(new Message { chatID = -1, command = "EXCEPTION", message = "Login failed. Username or password is incorrect." });
                     if (0 >= 1)
                     {

                     }
                     break;
                  default:
                     Console.WriteLine("Incorrect Command: Message = " + a.chatID + " : " + a.command + " : " + a.message);
                     //Console.WriteLine("Incorrect Command syntax found. Defaulting to sending message to chat.");
                     //a.message = DateTime.Now.ToString() + " : " + username + " : " + a.message;
                     //chatroomList.update(a);
                     break;
               }

            }
         }
         catch (Exception e)
         {
            // TODO do something else
            // Console.Out.WriteLine("Client " + username + " disconnected.");
         }
         finally
         {
            //TODO: Thread is being killed, clean up
         }
         return false;
      }


      private static bool isLoggedIn(string username)
      {
         foreach (ClientConnection client in clients)
         {
            if (client.username == username)
               return true;
         }
         return false;
      }

      private string[] ParseRegisterMessage(string message)
      {
         string[] usernamePassword = new string[2];
         usernamePassword[0] = message.Substring(0, USERNAME_MAX).Trim();
         usernamePassword[1] = message.Substring(USERNAME_MAX);
         return usernamePassword;
      }



      /// <summary>
      /// 
      /// </summary>
      public void OnCompleted()
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="error"></param>
      public void OnError(Exception error)
      {
         throw new NotImplementedException();
      }



      /// <summary>
      /// Observer pattern function for when new information is passed from the
      /// observable.
      /// </summary>
      /// <param name="value">The information to send to the client.</param>
      public void OnNext(Message value)
      {
         messageService.SendMessage(value);
      }

      /// <summary>
      /// Stops all clients and sends a message to each client that the connection is being halted.
      /// </summary>
      public static void StopAllClients()
      {
         lock (clients)
         {
            foreach (ClientConnection client in clients)
            {
               client.disconnect();
            }
            clients.Clear();
         }
      }
      private void SendChatroomList()
      {
         string list = "";
         List<ChatroomLogic> myChatrooms = new List<ChatroomLogic>();
         foreach (ChatroomLogic chatroom in chatroomList.chatrooms)
            if (chatroom.RegisteredUsers.Contains(this.userID))
               myChatrooms.Add(chatroom);


         foreach (ChatroomLogic c in myChatrooms)
            list += c.chatroomID + "," + c.name + ",";
         messageService.SendMessage(new Message { chatID = -1, command = "CHATROOMLIST", message = list });
      }



      /// <summary>
      /// Updates all clients with the current client username list. Called when a client disconnects or connects;
      /// </summary>
      /// <param name="client"></param>
      /// <param name="chatroomList"></param>
      private void sendClientList()
      {
         String list = "";
         foreach (ClientConnection c in ClientConnection.clients)
         {
            list += c.username + ",";
         }
         chatroomList.SendGlobalMessage(new Message { chatID = -1, command = "CLIENTLIST", message = list });
      }
   }
}
