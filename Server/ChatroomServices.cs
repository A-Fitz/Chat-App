using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Server
{
    class ChatroomServices
    {
        ChatroomDatabridge ChatroomDatabridge = new ChatroomDatabridge();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatroomID"></param>
        /// <returns></returns>
        public DataTable ChatHistory(int chatroomID)
        {
            return ChatroomDatabridge.ChatHistory(chatroomID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatroomID"></param>
        /// <param name="msg"></param>
        public void AddMessage(int chatroomID, String msg)
        {
            ChatroomDatabridge.AddMessage(chatroomID, msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatid"></param>
        /// <param name="userid"></param>
        /// <param name="hashword"></param>
        /// <param name="directmsg"></param>
        public void CreateChatroom(int chatid, int userid, String hashword, int directmsg)
        {
            ChatroomDatabridge.CreateChatroom(chatid, userid, hashword, directmsg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatid"></param>
        /// <returns></returns>
        public DataTable GetChatUsers(int chatid)
        {
            return ChatroomDatabridge.GetChatUsers(chatid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllChatrooms()
        {
            return ChatroomDatabridge.GetAllChatrooms();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatid"></param>
        /// <param name="userid"></param>
        /// <param name="chatpw"></param>
        public void AddUser(int chatid, int userid, String chatpw)
        {
            ChatroomDatabridge.AddUser(chatid, userid, chatpw);
        }
    }
}
