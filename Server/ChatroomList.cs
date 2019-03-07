using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   class ChatroomList
   {
      private static List<ChatroomLogic> chatrooms = new List<ChatroomLogic>();
      
      public void addChat(ChatroomLogic crl)
      {
         if(!chatrooms.Contains(crl))
            chatrooms.Add(crl);
      }

      public void update(Message msg)
      {
         if(chatrooms.Contains(msg.toChatroom))
            msg.toChatroom.update(msg);
      }

      public static ChatroomLogic idToChatroom(int id)
      {
         int a = chatrooms.FindIndex(x => x.chatroomID == id);
         if (a == -1)
            return null;
         return chatrooms.ElementAt(a);
      }

   }
}
