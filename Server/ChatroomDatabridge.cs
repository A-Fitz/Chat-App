using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Server
{
    public class ChatroomDatabridge
    {
        string connectionString = "Data Source=(DESCRIPTION ="
               + "(ADDRESS = (PROTOCOL = TCP)(HOST = maize.oit.uwplatt.edu)(PORT = 1521))"
               + "(CONNECT_DATA = (SID=EDDB) (SERVER = DEDICATED)));"
               + "User Id= vancemi;Password=Cathy1965Vanc@;";

        /// <summary>
        /// 
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
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GET_CHAT_HISTORY";
                    command.Parameters.Add("CHATID", OracleDbType.Int32).Value = chatroomID;

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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="chatid"></param>
        /// <param name="userid"></param>
        /// <param name="chatpw"></param>
        public bool AddUser(int chatid, int userid, String chatpw)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ADD_USER_TO_CHATROOM";
                    command.Parameters.Add("CHAT_ID", OracleDbType.Int32).Value = chatid;
                    command.Parameters.Add("USER_ID", OracleDbType.Int32).Value = userid;
                    command.Parameters.Add("CHATROOMPASSWORD", OracleDbType.Varchar2).Value = chatpw;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                { return false; }
            }
        }
    }
}
