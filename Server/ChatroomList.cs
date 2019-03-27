﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   class ChatroomList
   {
      private static List<ChatroomLogic> chatrooms = new List<ChatroomLogic>();

      /// <summary>
      /// 
      /// </summary>
      /// <param name="crl"></param>
      public void addChat(ChatroomLogic crl)
      {
         if(!chatrooms.Contains(crl))
            chatrooms.Add(crl);
      }

      public void update(Message msg)
      {
         ChatroomLogic chatroom = ChatroomList.idToChatroom(msg.chatID);
         if (chatrooms.Contains(chatroom))
            chatroom.update(msg);
      }

      public static ChatroomLogic idToChatroom(int id)
      {
         int a = chatrooms.FindIndex(x => x.chatroomID == id);
         if (a == -1)
            return null;
         return chatrooms.ElementAt(a);
      }

      public void SendGlobalMessage(Message message)
      {
         foreach (ClientConnection client in ClientConnection.clients)
            client.OnNext(message);
      }

      public void Stop()
      {
         ClientConnection.StopAllClients();
         //TODO cleanup any resources being held up
      }

   }
}
