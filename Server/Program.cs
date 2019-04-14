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
            ChatroomLogic mainRoom = new ChatroomLogic();
            chatroomList.addChat(mainRoom);

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
