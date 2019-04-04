﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Server
{
    public class UserDatabridge
    {
        string connectionString = "Data Source=(DESCRIPTION ="
                + "(ADDRESS = (PROTOCOL = TCP)(HOST = maize.oit.uwplatt.edu)(PORT = 1521))"
                + "(CONNECT_DATA = (SID=EDDB) (SERVER = DEDICATED)));"
                + "User Id= vancemi;Password=Cathy1965Vanc@;";

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