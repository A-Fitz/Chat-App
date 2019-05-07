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
      private const int USERNAME_MAX = 20;
      private const int HASHED_PW_SIZE = 20;
      private const int NUM_MSG_SUBSECTIONS = 2;
      private NetworkStream networkStream;
      public string username { get; set; } = "";
      public int userID { get; set; } = -1;
      private static int numClients = 0;
      private ChatroomList chatroomList;
      public static List<ClientConnection> clients { get; set; } = 
         new List<ClientConnection>();
      private List<ChatroomLogic> chatrooms = new List<ChatroomLogic>();
      private MessageService messageService;

      /// <summary>
      /// Constructor that requires a network stream to listen to and 
      /// a chatroom list.
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
      /// This method is not reasonably testable. It would 
      /// validate NetworkStream.
      /// </summary>
      public void disconnect()
      {
         networkStream.Dispose();
         networkStream.Close();
      }

      /// <summary>
      /// Subscribes this client to a chat. Any new information to the ChatroomLogic that
      /// this object is subsribed to will come through the 
      /// OnNext() function.
      /// </summary>
      /// <param name="crl"></param>
      public void subsribeToChat(ChatroomLogic crl)
      {
         crl.Subscribe(this);
         crl.RegisteredUsers.Add(this.userID);
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
      /// Main client loop that takes in data and does
      /// certain operations based
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
            while (true)
            {
               Message incomingMsg = messageService.GetMessage();
               if (incomingMsg == null)
                  return;
               switch (incomingMsg.command)
               {
                  case "SEND":
                     SendCommand(incomingMsg);
                     break;
                  case "NEW_CHAT":
                     NewChatCommand(incomingMsg);
                     break;
                  case "JOIN_CHAT"://and like the video down below
                     JoinChatCommand(incomingMsg);
                     break;
                  case "CLOSE":
                     CloseCommand();
                     return;
                  default:
                     Console.WriteLine("Incorrect Command: Message = " 
                        + incomingMsg.chatID + " : " + incomingMsg.command 
                        + " : " + incomingMsg.message);
                     break;
               }

            }
         }
         catch (Exception e)
         {
            disconnect();
            clients.Remove(this);
            sendClientList();
            Console.Out.WriteLine((username == "" ? 
               "Someone disconected." : username + " disconnected."));
         }
      }

      /// <summary>
      /// Checks to see if the client is sending a message
      /// to a valid chat room, then sends it to all
      /// subscribes members of that chat room.
      /// </summary>
      /// <param name="incomingMsg">Details about the message and the 
      /// chat room it will be sent to.</param>
      private void SendCommand(Message incomingMsg)
      {
         incomingMsg.message = DateTime.Now.ToString()
                        + " : " + username + " : " + incomingMsg.message;
         ChatroomLogic sendChatroom
            = chatroomList.idToChatroom(incomingMsg.chatID);
         if (sendChatroom != null
            && sendChatroom.RegisteredUsers.Contains(userID))
            chatroomList.update(incomingMsg, userID);
         else
            Console.WriteLine("Bad SEND message chatID");
      }

      /// <summary>
      /// Attempts to create a new chat for the client.
      /// </summary>
      /// <param name="incomingMsg">Details about the new chat.</param>
      private void NewChatCommand(Message incomingMsg)
      {
         //message = password for chatroom
         //chatID = wether it is a private room. 1 = direct message
         //room, 0 = normal password protected room
         ChatroomLogic tempChatroom = new ChatroomLogic();
         string chatname = incomingMsg.message.Substring(HASHED_PW_SIZE,
            incomingMsg.message.Length - HASHED_PW_SIZE);
         string hashword = incomingMsg.message.Substring(0, HASHED_PW_SIZE);
         if (ChatroomList.chatroomServices.CreateChatroom(chatname,
            tempChatroom.chatroomID,
            this.userID, hashword, incomingMsg.chatID))
         {

            chatroomList.addChat(tempChatroom);
            tempChatroom.name = chatname;
            tempChatroom.Subscribe(this);
            tempChatroom.RegisteredUsers.Add(this.userID);
            messageService.SendMessage(new Message
            {
               chatID = -1,
               command = "ACK",
               message = "Chatroom has been created"
            });
            SendChatroomList();
            SendChatHistory(tempChatroom.chatroomID);
         }
         else
         {
            messageService.SendMessage(new Message
            {
               chatID = -1,
               command = "EXCEPTION",
               message = "Chatroom name already taken"
            });
         }
      }

      /// <summary>
      /// Shuts down the socket for this client and cleanly
      /// closes the thread associated to this client.
      /// </summary>
      private void CloseCommand()
      {
         disconnect();
         clients.Remove(this);
         sendClientList();
         Console.Out.WriteLine((username == "" ?
            "Someone disconected." : username + " disconnected."));
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
               DataTable messages = ChatroomList.chatroomServices.ChatHistory(
                  chatroom.chatroomID);
               foreach (DataRow message in messages.Rows)
                  OnNext(new Message { chatID = chatroom.chatroomID,
                     command = "", message = message["message"].ToString() });
            }
         }
         sendClientList();
      }

      /// <summary>
      /// Sends the entire chat history of a specified chat room.
      /// </summary>
      /// <param name="chatID"></param>
      private void SendChatHistory(int chatID)
      {
         DataTable messages = 
            ChatroomList.chatroomServices.ChatHistory(chatID);
         foreach (DataRow message in messages.Rows)
            OnNext(new Message { chatID = chatID,
               command = "", message = message["message"].ToString() });
      }


      /// <summary>
      /// Handles when a user attempts to join a chat.
      /// </summary>
      /// <param name="incomingMsg">The message used to 
      /// login to a chat with.</param>
      private void JoinChatCommand(Message incomingMsg)
      {
         string hashword2 = incomingMsg.message.Substring(0, HASHED_PW_SIZE);
         int id = -1;

         if (int.TryParse(incomingMsg.message.Substring(HASHED_PW_SIZE,
            incomingMsg.message.Length - HASHED_PW_SIZE), out id))
         {
            ChatroomLogic tempChatroom2 =
               chatroomList.idToChatroom(id);
            if (tempChatroom2 != null)
            {

               if (ChatroomList.chatroomServices.AddUser(
                  tempChatroom2.chatroomID,
                  this.userID, hashword2))
               {
                  tempChatroom2.Subscribe(this);
                  tempChatroom2.RegisteredUsers.Add(this.userID);
                  messageService.SendMessage(
                     new Message
                     {
                        chatID = -1,
                        command = "ACK",
                        message = "Chatroom login succeded"
                     });
                  SendChatroomList();
                  SendChatHistory(tempChatroom2.chatroomID);
               }
               else
               {
                  messageService.SendMessage(
                     new Message
                     {
                        chatID = -1,
                        command = "EXCEPTION",
                        message = "Chatroom login failed"
                     });
                  return;
               }
            }
         }
         else
            messageService.SendMessage(
               new Message
               {
                  chatID = -1,
                  command = "EXCEPTION",
                  message = "Bad chatroom id"
               });
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
               Message incomingMsg = messageService.GetMessage();

               if (incomingMsg == null)
                  return false;
               string[] usernamePassword = ParseRegisterMessage(incomingMsg.message);
               switch (incomingMsg.command)
               {

                  case "REGISTER":
                     RegisterCommand(incomingMsg, usernamePassword, userService);
                     break;
                  case "LOGIN":
                     if (LoginCommand(incomingMsg, usernamePassword, userService))
                        return true;
                     break;
                  default:
                     Console.WriteLine("Incorrect Command: Message = " 
                        + incomingMsg.chatID + " : " + incomingMsg.command + " : " + incomingMsg.message);
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


      private void RegisterCommand(Message incomingMsg, string [] usernamePassword, UserService userService)
      {
         if (userService.CheckUsername(usernamePassword[0]))
         {
            if (!userService.RegisterUser(usernamePassword[0],
               usernamePassword[1]))
               messageService.SendMessage(new Message
               {
                  chatID = -1,
                  command = "EXCEPTION",
                  message = "Login failed"
               });
         }
         else
         {
            messageService.SendMessage(
               new Message
               {
                  chatID = -1,
                  command = "EXCEPTION",
                  message = usernamePassword[0] + " is taken."
               });
         }
         messageService.SendMessage(new Message
         {
            chatID = -1,
            command = "SUCCESS",
            message = "Registration successful!"
         });
      }


      private bool LoginCommand(Message incomingMsg, string[] usernamePassword, UserService userService)
      {
         if (isLoggedIn(usernamePassword[0]))
         {
            messageService.SendMessage(new Message
            {
               chatID = -1,
               command = "EXCEPTION",
               message = usernamePassword[0]
               + " is already logged in."
            });
         }
         else if (0 <= (userID
            = userService.VerifyLogin(usernamePassword[0],
            usernamePassword[1])))
         {
            username = usernamePassword[0];
            Thread.CurrentThread.Name = username;
            messageService.SendMessage(new Message
            {
               chatID = -1,
               command = "SUCCESS",
               message = "Login successful!"
            });
            return true;
         }
         else
            messageService.SendMessage(new Message
            {
               chatID = -1,
               command = "EXCEPTION",
               message =
               "Login failed. "
               + "Username or password is incorrect."
            });
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
         string[] usernamePassword = new string[NUM_MSG_SUBSECTIONS];
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
      /// Stops all clients and sends a message to each 
      /// client that the connection is being halted.
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
         messageService.SendMessage(new Message {
            chatID = -1,
            command = "CHATROOMLIST",
            message = list });
      }



      /// <summary>
      /// Updates all clients with the current client 
      /// username list. Called when a client disconnects or connects;
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
         chatroomList.SendGlobalMessage(new Message {
            chatID = -1,
            command = "CLIENTLIST",
            message = list });
      }
   }
}
