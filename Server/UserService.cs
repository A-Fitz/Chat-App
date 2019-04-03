using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class UserService
    {
        UserDatabridge UserDatabridge = new UserDatabridge();

        public bool CheckUsername(string username)
        {
            return UserDatabridge.CheckUsername(username);
        }

        public bool RegisterUser(string username, string password)
        {
            return UserDatabridge.RegisterUser(username, password);
        }

        public string getUserPassword(string username)
        {
            return UserDatabridge.GetUserHash(username);
        }
    }
}
