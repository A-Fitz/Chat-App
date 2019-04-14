using ChatApp.Interfaces;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace ChatApp
{
    /// <summary>
    /// This is an abstraction class for Networkstream so that we can Mock this classes implementation.
    /// This makes our code much more testable.
    /// </summary>
    public class ServerConnection : IServerConnection
    {
        private NetworkStream networkStream;

        /// <summary>
        /// Production Constructor
        /// </summary>
        /// <param name="networkStream">NetworkStream created by the TCP client</param>
        public ServerConnection(NetworkStream networkStream) : this()
        {
            this.networkStream = networkStream ?? throw new ArgumentNullException("networkStream");
        }

        /// <summary>
        /// Constructor for easier unit testing.
        /// </summary>
        public ServerConnection()
        {
                
        }

        /// <summary>
        /// Abstraction of NetworkStream's DataAvailable method. Returns true if there is data in the stream.
        /// </summary>
        public bool DataAvailable
        {
            get
            {
                return networkStream.DataAvailable;
            }
        }

        /// <summary>
        /// Abstraction of NetworkStream's Read method.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public int Read([In, Out] byte[] buffer, int offset, int size)
        {
            return networkStream.Read(buffer, offset, size);
        }

        /// <summary>
        /// Abstraction of NetworkStream's ReadByte method. Returns a char from the stream.
        /// </summary>
        /// <returns></returns>
        public char ReadByte()
        {
            return (char)networkStream.ReadByte();
        }

        /// <summary>
        /// Abstraction of NetworkStream's Write method.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public void Write(byte[] buffer, int offset, int size)
        {
            networkStream.Write(buffer, offset, size);
        }
    }
}
