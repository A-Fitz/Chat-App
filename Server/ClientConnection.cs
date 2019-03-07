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
      private List<IDisposable> subsribedChatroomDisposibles = new List<IDisposable>();

      public ClientConnection(NetworkStream ns, ChatroomList chatroomList)
      {
         this.networkStream = ns;
         this.chatroomList = chatroomList;
         userID = numClients++;
      }
      public void subsribeToChat(ChatroomLogic crl)
      {
         subsribedChatroomDisposibles.Add(crl.Subscribe(this));
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
               TCPMessage a = parseStream();
               Message b = new Message(a);
               switch (b.command)
               {
                  case "SETNAME":
                     username = b.text;
                     break;
                  case "SEND":
                     b.text = DateTime.Now.ToString() + " : " + (username == null ? ("Anonymous" + userID) : username) + " : " + b.text;
                     chatroomList.update(b);
                     break;
                  default:
                     b.text = DateTime.Now.ToString() + " : " + (username == null ? ("Anonymous" + userID) : username) + " : " + b.text;
                     chatroomList.update(b);
                     break;
               }
               
            }
         }
         finally
         {
            //TODO: Thread is being killed, clean up
         }
      }

      private TCPMessage parseStream()
      {
         TCPMessage output = null;
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
            output = JsonConvert.DeserializeObject<TCPMessage>(ASCIIEncoding.ASCII.GetString(data));
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
            TCPMessage a = new TCPMessage(msg);
            byte[] data = ASCIIEncoding.ASCII.GetBytes(JsonConvert.SerializeObject(a));
            int length = data.Length;
            byte[] lengthOut = ASCIIEncoding.ASCII.GetBytes(length.ToString() + ":");
            networkStream.Write(lengthOut, 0, lengthOut.Length);
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
