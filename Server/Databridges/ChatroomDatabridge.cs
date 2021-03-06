﻿using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

namespace Server
{
    public class ChatroomDatabridge
    {
        string connectionString = ConfigurationManager.AppSettings["OracleConnectionString"];

        /// <summary>
        /// Get chat history for a chatroom.
        /// </summary>
        /// <param name="chatroomID"></param>
        public DataTable ChatHistory(int chatroomID)
        {
            DataTable datatable = new DataTable();

            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select message from ChatHistory where chatroomId = " + chatroomID + " order by dateSent";

                    OracleDataAdapter da = new OracleDataAdapter(command);
                    da.Fill(datatable);
                    connection.Close();
                    da.Dispose();
                }
                catch (Exception e)
                { }
            }
            return datatable;
        }

        /// <summary>
        /// Add Message into chat history.
        /// </summary>
        /// <param name="chatroomID"></param>
        /// <param name="msg"></param>
        public void AddMessage(int chatroomID, int userid, string msg)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ADD_MESSAGE";
                    command.Parameters.Add("CURRENTCHATROOM", OracleDbType.Int32).Value = chatroomID;
                    command.Parameters.Add("user_id", OracleDbType.Int32).Value = userid;
                    command.Parameters.Add("NEWMESSAGE", OracleDbType.Varchar2).Value = msg;

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                { }
            }
        }

        /// <summary>
        /// Creates a chatroom and adds the user into the new chatroom. It is setup to allow for direct messages 
        /// </summary>
        /// <param name="chatid"></param>
        /// <param name="userid"></param>
        /// <param name="hashword"></param>
        /// <param name="directmsg"></param>
        public bool CreateChatroom(string chatroomName, int chatid, int userid, String hashword, int directmsg)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CREATE_CHATROOM";
                    command.Parameters.Add("CHAT_ID", OracleDbType.Int32).Value = chatid;
                    command.Parameters.Add("USER_ID", OracleDbType.Int32).Value = userid;
                    command.Parameters.Add("HASHWORD", OracleDbType.Varchar2).Value = hashword;
                    command.Parameters.Add("DIRECTMESSAGE", OracleDbType.Int32).Value = directmsg;
                    command.Parameters.Add("CHAT_NAME", OracleDbType.Varchar2).Value = chatroomName;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                { return false; }
            }
        }

        /// <summary>
        /// Calls Sproc to get all users(userid) in a chatroom
        /// </summary>
        /// <param name="chatid"></param>
        /// <returns></returns>
        public DataTable GetChatUsers(int chatid)
        {
            DataTable datatable = new DataTable();

            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select userid from ChatroomUserLink where chatroomId = " + chatid;

                    OracleDataAdapter da = new OracleDataAdapter(command);
                    da.Fill(datatable);
                    connection.Close();
                    da.Dispose();
                }
                catch (Exception e)
                { }
            }
            return datatable;
        }

        /// <summary>
        /// Calls sproc to get all chatrooms.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllChatrooms()
        {
            DataTable datatable = new DataTable();

            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select chatroomId, chatroomName from Chatroom";

                    OracleDataAdapter da = new OracleDataAdapter(command);
                    da.Fill(datatable);
                    connection.Close();
                }
                catch (Exception e)
                { }
            }
            return datatable;
        }

        /// <summary>
        /// Calls Sproc in database to add a user to the specified chatroom.
        /// </summary>
        /// <param name="chatid"></param>
        /// <param name="userid"></param>
        /// <param name="chatpw"></param>
        public int AddUser(int chatid, int userid, string chatpw)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    int success = -1;
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ADD_USER_TO_CHATROOM";
                    command.Parameters.Add("USER_ID", OracleDbType.Int32).Value = userid;
                    command.Parameters.Add("CHAT_ID", OracleDbType.Int32).Value = chatid;
                    command.Parameters.Add("CHATROOM_PASSWORD", OracleDbType.Varchar2).Value = chatpw;
                    command.Parameters.Add("PASSED", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                    success = (int)((Oracle.ManagedDataAccess.Types.OracleDecimal)command.Parameters["PASSED"].Value).Value;

                    connection.Close();
                    return success;
                }
                catch (Exception e)
                { return -1; }
            }
        }
    }
}
