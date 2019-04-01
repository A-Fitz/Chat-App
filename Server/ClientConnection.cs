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
      private List<ChatroomLogic> chatrooms = new List<ChatroomLogic>();

      /// <summary>
      /// Constructor that requires a network stream to listen to and a chatroom list.
      /// </summary>
      /// <param name="ns"></param>
      /// <param name="chatroomList"></param>
      public ClientConnection(NetworkStream ns, ChatroomList chatroomList)
      {
         this.networkStream = ns;
         this.chatroomList = chatroomList;
      }

      /// <summary>
      /// Cleans up the stream
      /// </summary>
      public void disconnect()
      {
         //TODO wait for the rest of a message or timeout
         networkStream.Dispose();
         networkStream.Close();

         //TODO Kill the thread if its still alive
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
            while (true)
            {
               Message a = parseStream();

               if (a == null)
                  return;
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
                     clients.Remove(this);
                     sendClientList(this, chatroomList);
                     Console.Out.WriteLine("Client " + username + " disconnected.");
                     return;
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
            // TODO do something else
            // Console.Out.WriteLine("Client " + username + " disconnected.");
         }
         finally
         {
            //TODO: Thread is being killed, clean up
         }
      }

      /// <summary>
      /// Parses incoming data into Message objects that the 
      /// rest of the program can use effectively.
      /// </summary>
      /// <returns></returns>
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
      /// Takes a Message object and writes it to the stream
      /// so that the client can parse it and deserialize it.
      /// </summary>
      /// <param name="msg">Message to be sent</param>
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

      /// <summary>
      /// Observer pattern function for when new information is passed from the
      /// observable.
      /// </summary>
      /// <param name="value">The information to send to the client.</param>
      public void OnNext(Message value)
      {
         WriteMessage(value);
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
