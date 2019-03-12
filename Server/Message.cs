using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   class Message
   {
      public Message()
      {

      }
      
      public Message(int chatID, string message, string command)
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
