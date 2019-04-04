using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ChatApp.Interfaces;
using System.Security.Cryptography;

namespace ChatApp.Services
{
   public class UserService : IUserService
   {
      IMessageService messageService;
      public UserService(NetworkStream stream)
      {
         messageService = new MessageService(stream);
      }
      
      public TCPMessage Login(string username, string password)
      {
         var paddedUsername = username.PadRight(20);
         var hashedPassword = hashPassword(password);

         messageService.SendMessage(new TCPMessage { chatID = 0, command = "LOGIN", message = paddedUsername + hashedPassword });

         return waitForResponse();
      }

      public TCPMessage RegisterUser(string username, string password)
      {
         var paddedUsername = username.PadRight(20);
         var hashedPassword = hashPassword(password);

         messageService.SendMessage(new TCPMessage { chatID = 0, command = "REGISTER", message = paddedUsername + hashedPassword });

         return waitForResponse();
      }


      /// <summary>
      /// Hash the password from passwordText using SHA1.
      /// </summary>
      /// <returns>byte array containing hashed password</returns>
      private string hashPassword(string password)
      {
         SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
         byte[] data = Encoding.ASCII.GetBytes(password);
         byte[] sha1data = sha1.ComputeHash(data);

         return new string(Encoding.ASCII.GetChars(sha1data));
      }

      private TCPMessage waitForResponse()
      {
         while (!messageService.CheckForMessages())
         {
            Thread.Sleep(1000);
         }

         return messageService.GetMessages().First();
      }
   }
}
