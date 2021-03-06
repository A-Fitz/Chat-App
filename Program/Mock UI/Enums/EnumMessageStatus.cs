﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
   /// <summary>
   /// Enums used for message status responses - contains custom descriptions used for UI.
   /// </summary>
    public enum EnumMessageStatus
    {
            [Description("Invalid message.")]
            invalid,
            [Description("Message sent successfully.")]
            successful,
            [Description("Message cannot be empty.")]
            empty,
            [Description("Message could not be sent.")]
            notSent,
            [Description("The connection has been closed.")]
            connectionClosed,
            [Description("unknown exception occured.")]
            unknown
    }

}
