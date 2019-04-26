//#define TESTING

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Data;

namespace Server
{
   class Program
   {
      public static int PORT = 12345;

      private static String HELP =
         "help       - Shows this documentation\n" +
         "exit       - Shuts down the entire server.\n" +
         "shutdown   - Shuts down the entire server.\n" +
         "restart    - Saves, resets, and restarts the server.\n";

      private static string HELP_EXIT = "Safely shuts down the server" +
         "and saves.";
      private static string HELP_RESTART = "Safely shutdown and startup the server while saving data.";


      static void Main(string[] args)
      {
         bool exit = false, restart = true;
         while (restart)
         {
            exit = false;
            restart = true;
            Console.Out.WriteLine("Server autostarting at port " + PORT);
            //Start server

            ChatroomList chatroomList = new ChatroomList();

            Console.WriteLine("Loading...");
            if (LoadSaveData(chatroomList))
            {
               Console.WriteLine("Loading successful");
            }
            else
            {
               Console.WriteLine("No data found. Starting with defaults.");
               ChatroomLogic mainRoom = new ChatroomLogic();
               ChatroomLogic mainRoom2 = new ChatroomLogic();
               mainRoom.name = "Global 1";
               mainRoom2.name = "Global 2";
               chatroomList.addChat(mainRoom);
               chatroomList.addChat(mainRoom2);
               //TODO: Add default chatrooms to SQL server
            }

            TcpListener serverSocket = new TcpListener(System.Net.IPAddress.Loopback, PORT);
            serverSocket.Start();
            Thread connectorThread = new Thread(() => handleIncomingConnections(serverSocket, chatroomList));
            connectorThread.Name = "Connector Thread";
            connectorThread.Priority = ThreadPriority.Lowest;
            connectorThread.Start();
            while (!exit)
            {
               string input = Console.In.ReadLine().Trim();
               switch (input.ToLower())
               {
                  case "help":
                     Console.Write(HELP);
                     break;
                  case "help exit":
                  case "help shutdown":
                     Console.WriteLine(HELP_EXIT);
                     break;
                  case "help restart":
                     Console.WriteLine(HELP_RESTART);
                     break;
                  case "exit":
                  case "shutdown":
                     exit = true;
                     restart = false;
                     break;
                  case "restart":
                     exit = true;
                     restart = true;
                     break;
                  default:
                     Console.WriteLine(input + " is not recognized as a command. Use ? or help for options.");
                     break;

               }
            }
            Console.WriteLine("Saving...");
            serverSocket.Stop();
            chatroomList.SendGlobalMessage(new Message { chatID = -1, command = "CLOSING", message = "0" });
            chatroomList.Stop();
            if (restart == true)
            {
               Console.WriteLine("Restarting...");
            }
         }
      }



      private static bool LoadSaveData(ChatroomList chatroomList)
      {
         int hightestChatroomID = 0;
         ChatroomServices chatroomServices = new ChatroomServices();
         UserService userService = new UserService();
         DataTable dataTable = chatroomServices.GetAllChatrooms();
         if (dataTable.Rows.Count != 0)
         {
            foreach (DataRow row in dataTable.Rows)
            {
               string name = row["chatroomname"].ToString();
               int id = int.Parse(row["chatroomid"].ToString());
               ChatroomLogic temp = new ChatroomLogic();
               temp.name = name;
               temp.chatroomID = id;
               hightestChatroomID = hightestChatroomID < id ? hightestChatroomID : id;
               chatroomList.addChat(temp);
               DataTable userTable = chatroomServices.GetChatUsers(temp.chatroomID);
               foreach (DataRow userRow in userTable.Rows)
               {
                  int userId = int.Parse(row["user_id"].ToString());
                  //temp.RegisteredUsers.Add();//TODO: Convert Userid to userName
               }
            }
            //TODO: Call "GetUsersInChatroom" for each chatroom and append registered users to that chatroom
            return true;
         }
         return false; 
      }
      

      /// <summary>
      /// One thread will be assigned to handling new connections and will create a new
      /// ClientConnection object for every new connection.
      /// </summary>
      /// <param name="serverSocket">The socket to listen for incoming connections</param>
      /// <param name="chatroomList">The current chatroomList</param>
      private static void handleIncomingConnections(TcpListener serverSocket, ChatroomList chatroomList)
      {
         try
         {
            while (true)
            {
               TcpClient socket = serverSocket.AcceptTcpClient();
               Console.WriteLine("A new client has connected");
               NetworkStream stream = socket.GetStream();
               ClientConnection client = new ClientConnection(stream, chatroomList);
               client.StartAsync();

               
            }
         }
         catch(ThreadAbortException tae)
         {
            //Console.WriteLine("Connector thread \"" + Thread.CurrentThread.Name + "\" left");
         }
         catch(SocketException se)
         {
            //Console.WriteLine("Connector thread \"" + Thread.CurrentThread.Name + "\" left");
         }
         finally
         {
            //Console.WriteLine("Connector thread \"" + Thread.CurrentThread.Name + "\" left finally block");
         }
      }

   }
}
