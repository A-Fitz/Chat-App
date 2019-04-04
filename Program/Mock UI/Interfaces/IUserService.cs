using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Interfaces
{
   public interface IUserService
   {
      TCPMessage RegisterUser(string username, string password);
      TCPMessage Login(string username, string password);
   }
}
