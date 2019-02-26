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
                    TcpClient socket = new TcpClient("127.0.0.1", 12345);
                    NetworkStream stream = socket.GetStream();
                    this.Hide();
                    var form1 = new Form1(stream);
                    form1.FormClosed += (s, args) => this.Close();
                    form1.Show();
             }
            else
             {
                 System.Windows.Forms.MessageBox.Show("Please Enter Valid Username.");
             }
            
        }

        private Boolean validUserName(String username)
        {
            if (username.Length > 0)
                return true;
            return false;
        }
    }
}
