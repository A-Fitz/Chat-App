using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System.Net;
using System.Net.Sockets;
using Moq;
namespace ServerUnitTests
{
   [TestClass]
   public class ChatroomLogicTests
   {
      [TestMethod]
      public void TestUpdate()
      {
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         chatroomLogic.update(new Message { chatID = 0, command = "SEND", message = "Chatroom login succeded" });
      }
      [TestMethod]
      public void TestSubscribe()
      {
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         Assert.AreEqual(true ,chatroomLogic.Subscribe(new ClientConnection(new Mock<NetworkStream>().Object, new Mock<ChatroomList>().Object)) != null);
      }
      [TestMethod]
      [ExpectedException(typeof(NotImplementedException))]
      public void TestDispose()
      {
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         IDisposable test = chatroomLogic.Subscribe(new ClientConnection(new Mock<NetworkStream>().Object, new Mock<ChatroomList>().Object));
         test.Dispose();
      }


   }
}
