using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService
    {
        UserDatabridge UserDatabridge = new UserDatabridge();

        /// <summary>
        /// This method determines if the username is in use.
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns></returns>
        public bool CheckUsername(string username)
        {
            return UserDatabridge.CheckUsername(username);
        }

        /// <summary>
        /// This method registers a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool RegisterUser(string username, string password)
        {
            return UserDatabridge.RegisterUser(username, password);
        }

        /// <summary>
        /// This method ensures that the password entered by the user
        /// matches the password for that username.
        /// </summary>
        /// <param name="username">Username to get password for</param>
        /// <param name="password">Password to check against</param>
        /// <returns></returns>
        public int VerifyLogin(string username, string password)
        {
            return UserDatabridge.GetUserHash(username) == password ? UserDatabridge.GetUserId(username) : -1;
        }
    }
}
