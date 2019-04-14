using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Interfaces
{
    public interface IMessageService
    {
        EnumMessageStatus SendMessage(TCPMessage message);
        IList<TCPMessage> GetMessages();
        bool CheckForMessages();
        bool ValidateMessage(string message);
    }
}
