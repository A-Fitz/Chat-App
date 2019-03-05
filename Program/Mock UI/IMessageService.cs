using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
    interface IMessageService
    {
        EnumMessageStatus SendMessage(TCPMessage message);
        IList<TCPMessage> GetMessages();
        bool CheckForMessages();
    }
}
