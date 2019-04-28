using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
   /// <summary>
   /// A TCPMessage is our only way of handling incoming and outgoing chat messages.
   /// </summary>
   public class TCPMessage
   {
      public TCPMessage()
      {
         this.command = "SEND";
      }
      /// <summary>
      /// Raw message that the client should send to the server.
      /// </summary>
      public string message { get; set; }
      /// <summary>
      /// Chatroom ID that the message should be sent to.
      /// </summary>
      public int chatID { get; set; }
      /// <summary>
      /// Additional commands attached to the message.
      /// </summary>
      public string command { get; set; }

   }
}
