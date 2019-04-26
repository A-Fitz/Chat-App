using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   class Chatroom
   {
      public int id { get; set;  }
      public String name { get; set; }
      public List<TCPMessage> messages { get; set; }

      public Chatroom(int id, String name)
      {
         this.id = id;
         this.name = name;
         messages = new List<TCPMessage>();
      }

      public override string ToString()
      {
         return name;
      }
   }
}
