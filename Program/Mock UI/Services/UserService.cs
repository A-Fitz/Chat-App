using System.Linq;
using System.Text;
using System.Threading;
using ChatApp.Interfaces;
using System.Security.Cryptography;

namespace ChatApp.Services
{
   public class UserService : IUserService
   {
      private readonly IMessageService messageService;

      /// <summary>
      /// Sets up a new UserService and MessageService with a network stream.
      /// </summary>
      /// <param name="stream"></param>
      public UserService(IServerConnection serverConnection, IMessageService messageService)
      {
         this.messageService = messageService;
      }
      
      /// <summary>
      /// Attempts to login to the server with a username and password. Server expects a username with a length of 20 so we pad
      /// it with 20 spaces. Sends a LOGIN message to the server and waits for its response.
      /// </summary>
      /// <param name="username">unpadded username</param>
      /// <param name="password">hashed password</param>
      /// <returns>A success or fail TCPMessage</returns>
      public TCPMessage Login(string username, string password)
      {
         var paddedUsername = username.PadRight(20);
         var hashedPassword = hashPassword(password);

         messageService.SendMessage(new TCPMessage { chatID = 0, command = "LOGIN", message = paddedUsername + hashedPassword });

         return waitForResponse();
      }
      
      /// <summary>
      /// Attempts to register a user with the server using the username and password. Server expects a username with a lenght of 20
      /// so we pad it with 20 spaces. Send a REGISTER message to the server and wait for its response.
      /// </summary>
      /// <param name="username">unpadded username</param>
      /// <param name="password">hashed password</param>
      /// <returns>A success or fail TCPMessage</returns>
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

      /// <summary>
      /// Used when we want to wait for a response from the server.
      /// </summary>
      /// <returns>TCPMessage with an important command response</returns>
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
