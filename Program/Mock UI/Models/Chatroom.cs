using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   /// <summary>
   /// Each chatroom will have an object of this type. Each has an id (chatID), name, and list of TCPMessages.
   /// </summary>
   class Chatroom
   {
      /// <summary>
      /// The chatroom ID is our only way of differentiating chatrooms for eachother programatically.
      /// </summary>
      public int id { get; set;  }
      /// <summary>
      /// The chatroom name is used for UI purposes only.
      /// </summary>
      public String name { get; set; }
      /// <summary>
      /// Need to maintain a seperate list of messages for each chatroom so that we can load messages for chatrooms that
      /// a user may not be viewing at the moment.
      /// </summary>
      public List<TCPMessage> messages { get; set; }

      /// <summary>
      /// Initializes a new chatroom with a specified chatID and name. Initializes the message list to empty.
      /// </summary>
      /// <param name="id"></param>
      /// <param name="name"></param>
      public Chatroom(int id, String name)
      {
         this.id = id;
         this.name = name;
         messages = new List<TCPMessage>();
      }

      /// <summary>
      /// Overriding ToString to display the chatroom name in the list of chatrooms.
      /// </summary>
      /// <returns></returns>
      public override string ToString()
      {
         return name + " [#" + id + "]";
      }
   }
}
