using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
    interface IMessageService
    {
        bool SendMessage(string message);
        bool ValidateMessage(string message);
    }
}
