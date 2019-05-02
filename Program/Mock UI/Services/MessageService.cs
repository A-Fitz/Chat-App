using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Sockets;
using ChatApp.Interfaces;

namespace ChatApp.Services
{
   /// <summary>
   /// Implementation of IMessageService that handles sending and recieving messages with a server connection.
   /// </summary>
   public class MessageService : IMessageService
   {
      private readonly IServerConnection serverConnection;

      /// <summary>
      /// Creates a new MessageService with a network stream.
      /// </summary>
      /// <param name="networkStream"></param>
      public MessageService(IServerConnection serverConnection)
      {
         this.serverConnection = serverConnection;
      }

      /// <summary>
      /// Lets us know if there are any unread messages in the stream.
      /// </summary>
      /// <returns>True if there are new messages, false otherwise</returns>
      public virtual bool CheckForMessages()
      {
         return serverConnection.DataAvailable;
      }

      /// <summary>
      /// Gets new messages from the stream. As long as CheckForMessage() returns true, we read in a message into a list of TCPMessages.
      /// </summary>
      /// <returns>List of TCPMessages</returns>
      public virtual IList<TCPMessage> GetMessages()
      {
         List<TCPMessage> messageList = new List<TCPMessage>();
         while (CheckForMessages())
         {
            var message = ReadInMessage();
            messageList.Add(JsonConvert.DeserializeObject<TCPMessage>(ASCIIEncoding.ASCII.GetString(message)));
         }
         return messageList;
      }

        public virtual TCPMessage ReadInFirstMessage()
        {
            var message = ReadInMessage();
            return JsonConvert.DeserializeObject<TCPMessage>(ASCIIEncoding.ASCII.GetString(message));
        }

      /// <summary>
      /// Attempts to send a message. Handles errors and exceptions for invalid messages and connection issues.
      /// Serializes the TCPMessage and writes it to the network stream.
      /// </summary>
      /// <param name="message"></param>
      /// <returns>An EnumMessageStatus of the appropriate success or failure type.</returns>
      public virtual EnumMessageStatus SendMessage(TCPMessage message)
      {
         if (!ValidateMessage(message.message))
            return EnumMessageStatus.invalid;
         try
         {
            var serializedMessage = JsonConvert.SerializeObject(message);
            serializedMessage = serializedMessage.Length + ":" + serializedMessage;
            byte[] data = Encoding.ASCII.GetBytes(serializedMessage);

            serverConnection.Write(data, 0, data.Length);
            return EnumMessageStatus.successful;
         }
         catch (ArgumentNullException)
         {
            return EnumMessageStatus.empty;
         }
         catch (SocketException)
         {
            return EnumMessageStatus.notSent;
         }
         catch (ObjectDisposedException)
         {
            return EnumMessageStatus.connectionClosed;
         }
         catch (Exception)
         {
            return EnumMessageStatus.unknown;
         }
      }

      /// <summary>
      /// Reads in a message from the stream and parses it.
      /// </summary>
      /// <returns>a byte array containing a message</returns>
      private byte[] ReadInMessage()
      {
         List<char> integerStringList = new List<char>();
         char character = serverConnection.ReadByte();
         while (character != ':')
         {
            integerStringList.Add(character);
            character = serverConnection.ReadByte();
         }
         int length = int.Parse(new string(integerStringList.ToArray()));
         byte[] data = new byte[length];
         serverConnection.Read(data, 0, data.Length);
         return data;

      }

      /// <summary>
      /// Check that a message contains at least one character, contains only ASCII characters, and does not contain only spaces.
      /// Returns true if the message is valid, false if the message is not valid
      /// </summary>
      /// <param name="message"></param>
      /// <returns></returns>
      public bool ValidateMessage(string message)
      {
         // If the message is empty (length is 0), it is invalid
         if (message.Length == 0)
            return false;

         bool messageContainsNonSpaces = false;
         const char spaceCharacter = ' ';

         foreach (char c in message)
         {
            // If the message contains a character out of ASCII range, it is invalid
            if (c >= sbyte.MaxValue)
               return false;

            // If the message contains a non-space character then it fufils that requirement, 
            //  but could still be invalid because of a non ASCII character, so still check the rest of the string
            if (!messageContainsNonSpaces && c != spaceCharacter)
               messageContainsNonSpaces = true;
         }

         if (messageContainsNonSpaces)
            return true;
         else
            return false;
      }
   }
}
