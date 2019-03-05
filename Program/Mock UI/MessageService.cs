using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Resources;

namespace Mock_UI
{
    public class MessageService : IMessageService
    {
        string status;
        TcpClient clientSocket;
        NetworkStream socketStream;
        public MessageService(NetworkStream socketStream)
        {
            this.socketStream = socketStream;
        }

        public bool CheckForMessages()
        {
            return socketStream.DataAvailable;
        }

        public IList<TCPMessage> GetMessages()
        {
            List<TCPMessage> messageList = new List<TCPMessage>();
            while (CheckForMessages())
            {
                var message = ReadInMessage();
                messageList.Add(JsonConvert.DeserializeObject<TCPMessage>(message.ToString()));
            }
            return messageList;            
        }

        public EnumMessageStatus SendMessage(TCPMessage message)
        {
            if (!ValidateMessage(message.message))
                return EnumMessageStatus.invalid;
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message);
                byte[] data = Encoding.ASCII.GetBytes(serializedMessage);

                socketStream.Write(data, 0, data.Length);
                //status = "Message sent successfully.";
                return EnumMessageStatus.successful;
            }
            catch (ArgumentNullException ex)
            {
                //status = "Message cannot be empty. " + ex.Message;
                return EnumMessageStatus.empty;
            }
            catch (SocketException ex)
            {
                //status = "Message could not be sent. " + ex.Message;
                return EnumMessageStatus.notSent;
            }
            catch (ObjectDisposedException ex)
            {
                //status = "The connection has been closed. " + ex.Message;
                return EnumMessageStatus.connectionClosed;
            }
            catch (Exception ex)
            {
                //status = "unknown exception occured. " + ex.Message;
                return EnumMessageStatus.unknown;
            }
        }

        private byte[] ReadInMessage()
        {
            var dataSize = socketStream.Length;
            char character;
            List<char> check = new List<char>();
            character = (char)socketStream.ReadByte();
            while (character != ':')
            {
                character = (char)socketStream.ReadByte();
                check.Add(character);
            }

            int messageLength = 0;
            if (!int.TryParse(check.Where(x => x != ':').ToString(), out messageLength))
            {
                return null;
            }

            byte[] message = new byte[messageLength];
            socketStream.Read(message, 0, messageLength);
            return message;

        }

        // Check that a message contains at least one character, contains only ASCII characters, and does not contain only spaces.
        // Returns true if the message is valid, false if the message is not valid
        private bool ValidateMessage(string message)
        {
            // If the message is empty (length is 0), it is invalid
            if (message.Length == 0)
                return false;

            bool messageContainsNonSpaces = false;
            const char spaceCharacter = ' ';

            foreach(char c in message)
            {
                // If the message contains a character out of ASCII range, it is invalid
                if(c >= sbyte.MaxValue)
                    return false;

                // If the message contains a non-space character then it fufils that requirement, 
                //  but could still be invalid because of a non ASCII character, so still check the rest of the string
                if (!messageContainsNonSpaces && c != spaceCharacter)
                    messageContainsNonSpaces = true;
            }

            if (!messageContainsNonSpaces)
                return true;
            else
                return false;
        }
    }
}
