using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
    class MessageService : IMessageService
    {
        public bool SendMessage(string message)
        {
            return true;
        }

        // Check that a message contains at least one character, contains only ASCII characters, and does not contain only spaces.
        // Returns true if the message is valid, false if the message is not valid
        public bool ValidateMessage(string message)
        {
            // If the message is empty (length is 0), it is invalid
            if (message.Length == 0)
                return false;

            bool messageContainsNonSpaces = false;
            const char spaceCharacter = ' ';

            foreach(char c in message)
            {
                // If the message contains a character out of ASCII range, it is invalid
                if(c >= sbyte.MaxValue)
                    return false;

                // If the message contains a non-space character then it fufils that requirement, 
                //  but could still be invalid because of a non ASCII character, so still check the rest of the string
                if (!messageContainsNonSpaces && c != spaceCharacter)
                    messageContainsNonSpaces = true;
            }

            if (!messageContainsNonSpaces)
                return true;
            else
                return false;
        }
    }
}
