using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mock_UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI.Tests
{
    [TestClass()]
    public class MessageServiceTests
    {
        /* Message Validation Testing */
        // valid: at least one character, AND only ascii characters, AND not only spaces
        // invalid: empty, OR contains non-ascii character, OR only spaces

        [TestMethod()]
        public void ValidationTest_ASCIICharacters_PASSES()
        {
            MessageService ms = new MessageService();
            Assert.IsTrue(ms.ValidateMessage(" \n !#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~"));
            Assert.IsTrue(ms.ValidateMessage("a            d               $"));
        }

        [TestMethod()]
        public void ValidationTest_OneCharacterNonSpace_PASSES()
        {
            MessageService ms = new MessageService();
            Assert.IsTrue(ms.ValidateMessage("-"));
        }

        [TestMethod()]
        public void ValidationTest_EmptyMessage_FAILS()
        {
            MessageService ms = new MessageService();
            Assert.IsFalse(ms.ValidateMessage(""));
        }

        [TestMethod()]
        public void ValidationTest_OnlySpaces_FAILS()
        {
            MessageService ms = new MessageService();
            Assert.IsFalse(ms.ValidateMessage(" "));
            Assert.IsFalse(ms.ValidateMessage("     "));
        }

        [TestMethod()]
        public void ValidationTest_ContainsNonASCII_FAILS()
        {
            MessageService ms = new MessageService();
            Assert.IsFalse(ms.ValidateMessage("è"));
            Assert.IsFalse(ms.ValidateMessage("      ↨"));
        }
    }
}