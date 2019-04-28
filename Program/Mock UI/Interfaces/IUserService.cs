using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Interfaces
{
   /// <summary>
   /// Interface used for the implementation of a UserService.
   /// </summary>
   public interface IUserService
   {
      TCPMessage RegisterUser(string username, string password);
      TCPMessage Login(string username, string password);
   }
}
