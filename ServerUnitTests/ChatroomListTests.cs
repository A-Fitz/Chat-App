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
         //chatroomList.update(new Message(0, "Hello World", "SEND"), 0);//This will make real additions to the sql database. Not sure how to test.
      }
   }
}
