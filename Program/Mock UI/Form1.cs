#define TEST1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
namespace Mock_UI
{
    public partial class Form1 : Form
    {
        // Message Services
        private NetworkStream stream;
        private IMessageService messageService;
        public Form1(NetworkStream stream)
        {
            this.stream = stream;
            messageService = new MessageService(stream);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
#if TEST1
            //get message from textbox
            String message = messageField.Text;
            byte [] dataOut = UTF8Encoding.ASCII.GetBytes(message.ToCharArray());

            //send message through server
            stream.Write(dataOut, 0, dataOut.Length);

            //revert textbox to empty
            messageField.Clear();
            this.Update();
#else
            //Real code here

#endif
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
#if TEST1

            byte[] dataIn = new byte[6054];
            if (stream.DataAvailable)
            {
                stream.Read(dataIn, 0, dataIn.Length);
                String inputStr = new String(ASCIIEncoding.UTF8.GetChars(dataIn, 0, dataIn.Length));
            }
            this.Update();
#else
            //Real code here
#endif
        }

        // When the send buttton is clicked: make a new TCPMessage and add the inputed text into it, try to send it
        //  and get the status, set the status label, clear the message field if successful, and set the status label.
        private void sendButton_Click(object sender, EventArgs e)
        {
            TCPMessage tcpMessage = new TCPMessage();
            tcpMessage.message = messageField.Text;
            tcpMessage.chatID = 0;

            EnumMessageStatus status = messageService.SendMessage(tcpMessage);

            if (status == EnumMessageStatus.successful)
                messageField.Clear();

            messageStatusLabel.Text = EnumExtensions.GetEnumDescription(status);            
        }

        // When the message field text is changed, clear the status label.
        private void messageField_TextChanged(object sender, EventArgs e)
        {
            messageStatusLabel.Text = "";
        }

        // For each tick of the readMessagesTimer (10s currently), check for new messages and add them to the chatList.
        private void readMessagesTimer_Tick(object sender, EventArgs e)
        {
            if(messageService.CheckForMessages())
            {
                IList<TCPMessage> messageList = messageService.GetMessages();
                foreach(TCPMessage t in messageList)
                {
                    chatList.Items.Add(t.message);
                }
            }
        }
    }
}
