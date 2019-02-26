using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
    class MessageService : IMessageService
    {
        public bool SendMessage(string message)
        {
            return true;
        }

        public bool ValidateMessage(string message)
        {


            return true;
        }
    }
}
