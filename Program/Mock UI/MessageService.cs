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

        public string SendMessage(TCPMessage message)
        {
            //Message Validation here
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message);
                byte[] data = Encoding.ASCII.GetBytes(serializedMessage);

                socketStream.Write(data, 0, data.Length);
                status = "Message sent successfully.";
            }
            catch (ArgumentNullException ex)
            {
                status = "Message cannot be empty. " + ex.Message;
            }
            catch (SocketException ex)
            {
                status = "Message could not be sent. " + ex.Message;
            }
            catch (ObjectDisposedException ex)
            {
                status = "The connection has been closed. " + ex.Message;
            }
            catch (Exception ex)
            {
                status = "unknown exception occured. " + ex.Message;
            }

            return status;
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

    }
}
