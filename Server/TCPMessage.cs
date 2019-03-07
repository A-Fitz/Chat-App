using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   class TCPMessage
   {
      public TCPMessage()
      {

      }
      public TCPMessage(Message msg)
      {
         this.chatID = msg.toChatroom.chatroomID;
         this.message = msg.text;
         this.command = msg.command;
      }
      public TCPMessage(int chatID, string message, string command)
      {
         this.chatID = chatID;
         this.message = message;
         this.command = command;
      }

      public int chatID { get; set; }
      public string message { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string command { get; set; }


   }
}
