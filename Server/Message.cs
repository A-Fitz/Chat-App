using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   class Message
   {
      public ChatroomLogic toChatroom { get;}
      public string text { get; set; }
      public string command { get;}

      public Message(TCPMessage tMsg)
      {
         toChatroom = ChatroomList.idToChatroom(tMsg.chatID);
         text = tMsg.message;
         this.command = tMsg.command;
      }

      public Message(ChatroomLogic toChatroom, string text, string command)
      {
         this.toChatroom = toChatroom;
         this.text = text;
         this.command = command;
      }


   }
}
