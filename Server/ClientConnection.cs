using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server
{
   class ClientConnection : IObserver<Message>
   {
      private NetworkStream networkStream;
      public string username { get; set; }
      private static int numClients = 0;
      private ChatroomList chatroomList;
      public static List<ClientConnection> clients { get; set; } = new List<ClientConnection>();

      public ClientConnection(NetworkStream ns, ChatroomList chatroomList)
      {
         this.networkStream = ns;
         this.chatroomList = chatroomList;
      }

      public void disconnect()
      {
         clients.Remove(this);
         sendClientList(this, chatroomList);
         //TODO wait for the rest of a message or timeout
         networkStream.Dispose();
         networkStream.Close();
         //TODO Kill the thread if its still alive
      }

      public void subsribeToChat(ChatroomLogic crl)
      {
         crl.Subscribe(this);
      }

      public void StartAsync()
      {
         Thread clientThread = new Thread(getMessages);

         clientThread.Start();
         clients.Add(this);
      }

      private void getMessages()
      {
         try
         {
            while (true)
            {
               Message a = parseStream();

               if(a == null)
                  throw new Exception("Connection was closed");
               switch (a.command)
               {
                  case "SETNAME":
                     username = a.message;
                     Thread.CurrentThread.Name = a.message;
                     // update all clients when new connected client
                     sendClientList(this, chatroomList);
                     break;
                  case "SEND":
                     a.message = DateTime.Now.ToString() + " : " +  username + " : " + a.message;
                     chatroomList.update(a);
                     break;
                  case "CLOSE":
                     disconnect();
                     throw new Exception("Connection was closed");
                  default:
                     Console.WriteLine("Incorrect Command syntax found. Defaulting to sending message to chat.");
                     a.message = DateTime.Now.ToString() + " : " +  username + " : " + a.message;
                     chatroomList.update(a);
                     break;
               }
               
            }
         }
         catch(Exception e)
         {
            Console.Out.WriteLine("Client " + username + " disconnected.");
         }
         finally
         {
            //TODO: Thread is being killed, clean up
         }
      }

      private Message parseStream()
      {
         Message output = null;
         try
         {
            List<Char> integerStringList = new List<char>();
            char character = (char)networkStream.ReadByte();
            while (character != ':')
            {
               integerStringList.Add(character);
               character = (char)networkStream.ReadByte();
            }
            int length = int.Parse(new string(integerStringList.ToArray()));
            byte[] data = new byte[length];
            networkStream.Read(data, 0, data.Length);
            output = JsonConvert.DeserializeObject<Message>(ASCIIEncoding.ASCII.GetString(data));
         }
         catch(Exception e)
         {
            Console.WriteLine(e.ToString());
         }
         return output;
      }


      public void OnCompleted()
      {
         throw new NotImplementedException();
      }

      public void OnError(Exception error)
      {
         throw new NotImplementedException();
      }

      private void WriteMessage(Message msg)
      {
         try
         {
            string jsonData = JsonConvert.SerializeObject(msg);
            byte [] data = ASCIIEncoding.ASCII.GetBytes(jsonData.Length + ":" + jsonData);
            networkStream.Write(data, 0, data.Length);
         }
         catch (Exception e)
         {
            //Console.WriteLine(e.ToString());
         }
      }

      public void OnNext(Message value)
      {
         WriteMessage(value);
      }

      public static void StopAllClients()
      {
         foreach (ClientConnection client in clients)
         {
            client.disconnect();
         }
         clients.Clear();
      }

      /// <summary>
      /// Updates all clients with the current client username list. Called when a client disconnects or connects;
      /// </summary>
      /// <param name="client"></param>
      /// <param name="chatroomList"></param>
      private void sendClientList(ClientConnection client, ChatroomList chatroomList)
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
