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
      private string username;
      private int userID;
      private static int numClients = 0;
      private ChatroomList chatroomList;
      

      public ClientConnection(NetworkStream ns, ChatroomList chatroomList)
      {
         this.networkStream = ns;
         this.chatroomList = chatroomList;
         userID = numClients++;
      }
      public void subsribeToChat(ChatroomLogic crl)
      {
         crl.Subscribe(this);
      }

      public void start()
      {
         new Thread(getMessages).Start();
      }

      private void getMessages()
      {
         try
         {
            while (true)
            {
               Message a = parseStream();
               switch (a.command)
               {
                  case "SETNAME":
                     username = a.message;
                     break;
                  case "SEND":
                     a.message = DateTime.Now.ToString() + " : " + (username == null ? ("Anonymous" + userID) : username) + " : " + a.message;
                     chatroomList.update(a);
                     break;
                  default:
                     Console.WriteLine("Incorrect Command syntax found. Defaulting to sending message to chat.");
                     a.message = DateTime.Now.ToString() + " : " + (username == null ? ("Anonymous" + userID) : username) + " : " + a.message;
                     chatroomList.update(a);
                     break;
               }
               
            }
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

      private void writeMessage(Message msg)
      {
         try
         {
            string jsonData = JsonConvert.SerializeObject(msg);
            byte [] data = ASCIIEncoding.ASCII.GetBytes(jsonData.Length + ":" + jsonData);
            networkStream.Write(data, 0, data.Length);
         }
         catch (Exception e)
         {
            Console.WriteLine(e.ToString());
         }
      }

      public void OnNext(Message value)
      {
         writeMessage(value);
      }
   }
}
