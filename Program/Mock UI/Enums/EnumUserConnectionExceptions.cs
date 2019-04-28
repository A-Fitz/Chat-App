using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
   /// <summary>
   /// Eums used for connection exeption responses - contains custom descriptions used in UI.
   /// </summary>
    public enum EnumUserConnectionExceptions
    {
      [Description("Please enter a valid username.")]
      invalidUsername,
      [Description("Please enter a valid password.")]
      invalidPassword,
      [Description("Incorect IP address or port. Programmers messed up.")]
      incorrectIP,
      [Description("Unknown exception occured.")]
      unknown
   }

}
