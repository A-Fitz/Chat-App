using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   public class MessageService
   {

      private NetworkStream networkStream;

      public MessageService(NetworkStream networkStream)
      {
         this.networkStream = networkStream;
      }

      /// <summary>
      /// Takes a Message object and writes it to the stream
      /// so that the client can parse it and deserialize it.
      /// </summary>
      /// <param name="message">Message to be sent</param>
      /// <param name="networkStream">Network stream to send it through</param>
      public void SendMessage(Message message)
      {
         try
         {
            string jsonData = JsonConvert.SerializeObject(message);
            byte[] data = ASCIIEncoding.ASCII.GetBytes(jsonData.Length + ":" + jsonData);
            networkStream.Write(data, 0, data.Length);
         }
         catch (Exception e)
         {
         }
      }


      /// <summary>
      /// Parses incoming data into Message objects that the 
      /// rest of the program can use effectively.
      /// </summary>
      /// <param name="networkStream">Network stream to send it through</param>
      /// <returns></returns>
      public Message GetMessage()
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
         catch (Exception e)
         {
         }
         return output;
      }



   }
}
