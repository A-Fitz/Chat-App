using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   /// <summary>
   /// Manages ChatroomLogic objects and also acts
   /// as a gateway to all chatrooms.
   /// </summary>
   class ChatroomList
   {
      public List<ChatroomLogic> chatrooms { get; set;} = new List<ChatroomLogic>();
      public static ChatroomServices chatroomServices { get; set; } = new ChatroomServices();
      /// <summary>
      /// Adds a ChatroomLogic object to the list managed by this
      /// class.
      /// </summary>
      /// <param name="crl">ChatroomLogic to add</param>
      public void addChat(ChatroomLogic crl)
      {
         if(!chatrooms.Contains(crl))
            chatrooms.Add(crl);
      }

      /// <summary>
      /// All messages with the command "SEND" will come through this function.
      /// This function acts as a main pipe for all messages and sends
      /// an update to the proper ChatroomLogic. Does nothing 
      /// if the ChatroomLogic object is not found.
      /// </summary>
      /// <param name="msg"></param>
      public void update(Message msg)
      {

         ChatroomLogic chatroom = idToChatroom(msg.chatID);
         if (chatrooms.Contains(chatroom))
         {
            chatroomServices.AddMessage(msg.chatID, msg.message);
            chatroom.update(msg);
         }
      }

      /// <summary>
      /// Converts an integer representation of the chatroom
      /// to a ChatroomLogic object or null if not found.
      /// </summary>
      /// <param name="id">chatID to convert to a ChatroomLogic object</param>
      /// <returns></returns>
      public ChatroomLogic idToChatroom(int id)
      {
         int a = chatrooms.FindIndex(x => x.chatroomID == id);
         if (a == -1)
            return null;
         return chatrooms.ElementAt(a);
      }

      /// <summary>
      /// Sends one message to each client who is connected 
      /// to atleast one chat.
      /// </summary>
      /// <param name="message">Message to be sent.</param>
      public void SendGlobalMessage(Message message)
      {
         foreach (ClientConnection client in ClientConnection.clients)
            client.OnNext(message);
      }

      /// <summary>
      /// Stops all clients abruptly and will not
      /// return until successfull.
      /// </summary>
      public void Stop()
      {
         ClientConnection.StopAllClients();
         //TODO cleanup any resources being held up
      }

   }
}
