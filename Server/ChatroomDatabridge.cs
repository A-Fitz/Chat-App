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
        public void PopulateMessages(int chatroomID)
        {
            DataTable datatable = new DataTable();

            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GET_MESSAGES";
                    command.Parameters.Add("CURRENTCHATROOM", OracleDbType.Varchar2).Value = chatroomID;

                    OracleDataAdapter da = new OracleDataAdapter(command);
                    da.Fill(datatable);
                    connection.Close();
                    da.Dispose();
                }
                catch (Exception e)
                { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatroomID"></param>
        /// <param name="msg"></param>
        public void AddMessage(int chatroomID, String msg)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ADD_MESSAGE";
                    command.Parameters.Add("CURRENTCHATROOM", OracleDbType.Varchar2).Value = chatroomID;
                    command.Parameters.Add("MESSAGE", OracleDbType.Int32).Value = msg;

                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                { }
            }
        }
    }
}
