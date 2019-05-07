//This is our main package class we will use for networking 
//purposes.
//Author(s): Ryan, Mitch, Liam, Austin
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   /// <summary>
   /// This is our main package class we will use for networking 
   /// purposes.
   /// </summary>
   public class Message
   {
      /// <summary>
      /// Directly related to a ChatroomLogic object.
      /// Use ChatroomLogic.idToChatroom(int id) to get
      /// the object associated with this ID.
      /// </summary>
      public int chatID { get; set; }

      /// <summary>
      /// The actual data being sent. Can be different
      /// based on the command.
      /// </summary>
      public string message { get; set; }
      /// <summary>
      /// This is the first thing checked on client or server
      /// side. Determines the use of the Message object.
      /// </summary>
      public string command { get; set; }

      /// <summary>
      /// Empty default constructor needed for JSON serialization and 
      /// deserialization.
      /// </summary>
      public Message() { }

      /// <summary>
      /// Creates a message based on the given parameters.
      /// </summary>
      /// <param name="chatID"></param>
      /// <param name="message"></param>
      /// <param name="command"></param>
      public Message(int chatID, string message, string command)
      {
         this.chatID = chatID;
         this.message = message;
         this.command = command;
      }




   }
}
