using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    public class TCPMessage
    {
        public TCPMessage()
        {
            this.command = "SEND";
        }
        /// <summary>
        /// Raw message that the clinet should send to the server.
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Chatroom ID that the message should be sent to.
        /// </summary>
        public int chatID { get; set; }
        /// <summary>
        /// Additional commands attached to the message.
        /// </summary>
        public string command { get; set; }

    }
}
