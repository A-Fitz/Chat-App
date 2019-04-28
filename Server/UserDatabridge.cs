using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Server
{
    /// <summary>
    /// Handles getting the information from the database for use.
    /// </summary>
    public class UserDatabridge
    {
        string connectionString = "Data Source=(DESCRIPTION ="
                + "(ADDRESS = (PROTOCOL = TCP)(HOST = maize.oit.uwplatt.edu)(PORT = 1521))"
                + "(CONNECT_DATA = (SID=EDDB) (SERVER = DEDICATED)));"
                + "User Id= vancemi;Password=Cathy1965Vanc@;";


        /// <summary>
        /// This method registers a user to the chatroom service by sending
        /// their information to the database to create a new entry in the 
        /// login and user table.
        /// </summary>
        /// <param name="username">The desired username of the new user</param>
        /// <param name="password">The password of the new user</param>
        /// <returns></returns>
        public bool RegisterUser(string username, string password)
        {
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ADD_NEW_USER";
                    command.Parameters.Add("NEWUSERNAME", OracleDbType.Varchar2).Value = username;
                    command.Parameters.Add("PASSWORD", OracleDbType.Varchar2).Value = password;

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (OracleException e)
                {
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserId(string username)
        {
            int userid = -1;
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GET_USERID";
                    command.Parameters.Add("USERNAMEIN", OracleDbType.Varchar2).Value = username;
                    command.Parameters.Add("USERIDIN", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    userid = (int)((Oracle.ManagedDataAccess.Types.OracleDecimal)command.Parameters["USERIDIN"].Value).Value;
                    connection.Close();
                }
                catch (Exception e)
                {
                    //exception message
                }

            }

            return userid;
        }

        /// <summary>
        /// This method checks the database to determine whether or not there
        /// is already a user that has the username that is being passed to it.
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns></returns>
        public bool CheckUsername(string username)
        {

            int available = -1;
            
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CHECK_USERNAME_AVAILABILITY";
                    command.Parameters.Add("NEWUSERNAME", OracleDbType.Varchar2).Value = username;
                    command.Parameters.Add("AVAILABLE", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    available = (int)((Oracle.ManagedDataAccess.Types.OracleDecimal) command.Parameters["AVAILABLE"].Value).Value;
                    connection.Close();
                }
                catch (Exception e)
                {
                    //exception message
                }

            }

            return available == -1;
        }

        /// <summary>
        /// This method gets the hashed password of the user whose username
        /// is passed. 
        /// </summary>
        /// <param name="username">Username whose password looking for</param>
        /// <returns></returns>
        public string GetUserHash(string username)
        {
            string password = "";

            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GET_USER_HASHWORD";
                    command.Parameters.Add("CURRENTUSERNAME", OracleDbType.Varchar2).Value = username;

                    var hashword = new OracleParameter
                    {
                        ParameterName = "HASHWORD",
                        OracleDbType = OracleDbType.Varchar2,
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };

                    command.Parameters.Add(hashword);

                    command.ExecuteNonQuery();
                    password = ((Oracle.ManagedDataAccess.Types.OracleString)command.Parameters["HASHWORD"].Value).Value.ToString();
                    connection.Close();                   
                }
                catch (OracleException e)
                {
                    return password;
                }
                catch (Exception e)
                {
                    return password;
                }

                return password;
            }
        }
    }
}