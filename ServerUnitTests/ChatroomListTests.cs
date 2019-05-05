using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;

namespace ServerUnitTests
{
   [TestClass]
   public class ChatroomListTests
   {
      [TestMethod]
      public void TestAddChat()
      {
         ChatroomList chatroomList = new ChatroomList();
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         chatroomList.addChat(chatroomLogic);
         chatroomList.addChat(chatroomLogic);
      }

      [TestMethod]
      public void TestUpdate()
      {
         ChatroomList chatroomList = new ChatroomList();
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         chatroomList.addChat(chatroomLogic);
         //chatroomList.update(new Message(0, "Hello World", "SEND"), 0);//This will make real additions to the sql database and send TCP packets. Not sure how to test.
      }
      [TestMethod]
      public void TestIDToChatroom()
      {
         ChatroomList chatroomList = new ChatroomList();
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         chatroomList.addChat(chatroomLogic);
         int id = chatroomLogic.chatroomID;
         chatroomList.addChat(new ChatroomLogic());
         Assert.AreEqual(chatroomLogic, chatroomList.idToChatroom(id));
         Assert.AreNotEqual(chatroomLogic, chatroomList.idToChatroom(id + 1));
      }
      [TestMethod]
      public void TestSendGlobalMessage()
      {
         ChatroomList chatroomList = new ChatroomList();
         chatroomList.SendGlobalMessage(new Message(-1, "Hello World", "SEND"));
      }
      [TestMethod]
      public void TestStop()
      {
         ChatroomList chatroomList = new ChatroomList();
         ChatroomLogic chatroomLogic = new ChatroomLogic();
         chatroomList.addChat(chatroomLogic);
         chatroomList.addChat(new ChatroomLogic());
         chatroomList.Stop();
      }
   }
}
