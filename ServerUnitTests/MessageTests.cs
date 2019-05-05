using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;

namespace ServerUnitTests
{
   [TestClass]
   public class MessageTests
   {
      [TestMethod]
      public void TestMessage()
      {
         Message message = new Message(0, "Hello World!", "SEND");
         Assert.AreEqual(0, message.chatID);
         Assert.AreEqual("Hello World!", message.message);
         Assert.AreEqual("SEND", message.command);
         message.chatID = 1;
         message.message = "Goodbye World";
         message.command = "EXCEPTION";
         Assert.AreEqual(1, message.chatID);
         Assert.AreEqual("Goodbye World", message.message);
         Assert.AreEqual("EXCEPTION", message.command);
      }
   }
}
