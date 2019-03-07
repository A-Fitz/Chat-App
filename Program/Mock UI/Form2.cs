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
using Newtonsoft.Json;

namespace Mock_UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (validUserName(userNameText.Text))
                {
                    var newConnection = setupNewConnection();
                    this.Hide();
                    var form1 = new Form1(newConnection);
                    form1.FormClosed += (s, args) => this.Close();
                    form1.Show();
             }
            else
             {
                 System.Windows.Forms.MessageBox.Show("Please Enter Valid Username.");
             }
            
        }

        private NetworkStream setupNewConnection()
        {
            TcpClient socket = new TcpClient("127.0.0.1", 12345);
            NetworkStream stream = socket.GetStream();

            var newUser = new TCPMessage { chatID = 0, message = userNameText.Text, command = "SETNAME" };
            var msg = JsonConvert.SerializeObject(newUser);

            stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);

            return stream;
        }

        private Boolean validUserName(String username)
        {
            if (username.Length > 0)
                return true;
            return false;
        }
    }
}
