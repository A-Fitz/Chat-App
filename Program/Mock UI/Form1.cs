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

namespace Mock_UI
{
    public partial class Form1 : Form
    {
        private NetworkStream stream;
        public Form1(NetworkStream s)
        {
            stream = s;
            InitializeComponent();
            timer1.Start();
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
                displayField.AppendText(inputStr + "\r\n"); //"\r\n" is new line for textbox
            }
            this.Update();
#else
            //Real code here
#endif
        }
    }
}
