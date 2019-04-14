using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatApp.Services;
using ChatApp.Interfaces;
using Moq;

namespace ChatApp.Tests
{
    [TestClass]
    public class MessageServiceTests
    {
        private readonly IMessageService messageService;
        private readonly Mock<ServerConnection> mockNetworkStream;

        public MessageServiceTests()
        {
            mockNetworkStream = new Mock<ServerConnection>();
            messageService = new MessageService(mockNetworkStream.Object);
        }

        /* Message Validation Testing */
        // valid: at least one character, AND only ascii characters, AND not only spaces
        // invalid: empty, OR contains non-ascii character, OR only spaces

        [TestMethod]
        public void ValidationTest_ASCIICharacters_PASSES()
        {
            Assert.IsTrue(messageService.ValidateMessage(" \n !#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~"));
            Assert.IsTrue(messageService.ValidateMessage("a            d               $"));
        }

        [TestMethod]
        public void ValidationTest_OneCharacterNonSpace_PASSES()
        {
            Assert.IsTrue(messageService.ValidateMessage("-"));
        }

        [TestMethod]
        public void ValidationTest_EmptyMessage_FAILS()
        {
            Assert.IsFalse(messageService.ValidateMessage(""));
        }

        [TestMethod]
        public void ValidationTest_OnlySpaces_FAILS()
        {
            Assert.IsFalse(messageService.ValidateMessage(" "));
            Assert.IsFalse(messageService.ValidateMessage("     "));
        }

        [TestMethod]
        public void ValidationTest_ContainsNonASCII_FAILS()
        {
            Assert.IsFalse(messageService.ValidateMessage("è"));
            Assert.IsFalse(messageService.ValidateMessage("      ↨"));
        }

        
    }
}