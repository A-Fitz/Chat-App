using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using Moq;
namespace ServerUnitTests
{
   [TestClass]
   public class ClientConnectionTests
   {

      private Mock<ChatroomList> chatroomList;
      private Mock<NetworkStream> networkStream;

      [TestMethod]
      public void TestSubsribeToChat()
      {
         networkStream = new Mock<NetworkStream>();

         chatroomList = new Mock<ChatroomList>();
         ClientConnection clientConnection = new ClientConnection(networkStream.Object, chatroomList.Object);


      }
   }
}
