using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spike1_C
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] specialChars = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x00, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x12 };
            //Test 1
            String ipAddress = "127.0.0.1";
            Int32 port = 12345;
            TcpClient client = new TcpClient(ipAddress, port);
            byte[] data = new byte[256];
            data = ASCIIEncoding.ASCII.GetBytes("TEST".ToCharArray());
            Stream s = client.GetStream();
            s.Write(data, 0, data.Length);


            //Test 2
            byte[] data2 = new byte[256];
            s.Read(data2, 0, data2.Length);
            s.Write(data2, 0, data2.Length);


            s.Close();
        }
    }
}
