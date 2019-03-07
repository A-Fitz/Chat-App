﻿//#define TESTING

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
         "?          - Shows this documentation/n" +
         "help       - Shows this documentation/n" +
         "exit       - Shuts down the entire server./n" +
         "shutdown   - Shuts down the entire server./n" +
         "restart    - Saves, resets, and restarts the server./n";

#if !TESTING
      static void Main(string[] args)
      {
         Console.Out.WriteLine("Server autostarting at port " + PORT);
         //Start server
         ChatroomList chatroomList = new ChatroomList();
         ChatroomLogic mainRoom = new ChatroomLogic();
         chatroomList.addChat(mainRoom);
         bool exit = false;
         TcpListener serverSocket = new TcpListener(System.Net.IPAddress.Loopback, PORT);
         serverSocket.Start();
         Thread connectorThread = new Thread(() => handleIncomingConnections(serverSocket, chatroomList));
         connectorThread.Start();
         while (!exit)
         {
            if (Console.In.ReadLine().Trim() == "exit")
               exit = true;
            
         }
         connectorThread.Abort();
         //Get handles to all threads and abort all
         //Shutdown server
      }
      public static void handleIncomingConnections(TcpListener serverSocket, ChatroomList chatroomList)
      {
         try
         {
            while (true)
            {
               TcpClient socket = serverSocket.AcceptTcpClient();
               Console.WriteLine("Address family: " + socket.Client.AddressFamily.ToString());
               NetworkStream stream = socket.GetStream();
               ClientConnection client = new ClientConnection(stream, chatroomList);
               client.subsribeToChat(ChatroomList.idToChatroom(0));
               client.start();
               
            }
         }
         catch(ThreadAbortException tae)
         {
            Console.WriteLine("Connector thread left");
         }
         finally
         {
            Console.WriteLine("Connector thread left");
         }
      }

#else


        static void Main(string[] args)
        {
            try
            {
            TCPMessage steve = new TCPMessage(42, "Hello World", "WELCOME");
            string ba = JsonConvert.SerializeObject(steve);
            TCPMessage steve2 = JsonConvert.DeserializeObject<TCPMessage>(ba);
            Console.Out.WriteLine(steve2.chatID + steve2.command + steve2.message);
            /*
                byte[] specialChars = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x00, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x12 };
                Console.Out.WriteLine("Server testing at port " + PORT);
                //Start testing
                //Test 1
                TcpListener serverSocket = new TcpListener(System.Net.IPAddress.Loopback, 12345);
                serverSocket.Start();
                TcpClient socket = serverSocket.AcceptTcpClient();
                NetworkStream stream = socket.GetStream();
                byte[] data = new byte[256];
                Thread.Sleep(1000);
                int bytesRead = stream.Read(data, 0, data.Length);
                Console.WriteLine("Read this many bytes: " + bytesRead);
                if (new string(ASCIIEncoding.UTF8.GetChars(data, 0, bytesRead)) == "TEST")
                {
                    System.Console.Out.WriteLine("Test 1 PASSED");
                    Console.Out.WriteLine(new string(ASCIIEncoding.UTF8.GetChars(data, 0, bytesRead)));
                }

                else
                {
                    System.Console.Error.WriteLine("Test 1 FAILED");
                    Console.Out.WriteLine(new string(ASCIIEncoding.UTF8.GetChars(data, 0, bytesRead)));
                }
                //Test 2
                data = specialChars;
                stream.Write(data, 0, data.Length);
                byte[] data2 = new byte[specialChars.Length];
                Console.WriteLine("Read this many bytes: " + stream.Read(data2, 0, data2.Length));
                if (data2.SequenceEqual(specialChars))
                {
                    System.Console.Out.WriteLine("Test 2 PASSED");
                }
                else
                {
                    System.Console.Error.WriteLine("Test 2 FAILED");
                }

                socket.Close();
                //Test 3
                */
         }

         catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }
            Console.Out.WriteLine("End testing");
            Console.In.ReadLine();


        }
#endif

   }
}