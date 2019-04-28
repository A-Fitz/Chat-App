using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Interfaces
{
   /// <summary>
   /// Interface used for the implementation of a MessageService.
   /// </summary>
   public interface IMessageService
   {
      EnumMessageStatus SendMessage(TCPMessage message);
      IList<TCPMessage> GetMessages();
      bool CheckForMessages();
      bool ValidateMessage(string message);
   }
}
