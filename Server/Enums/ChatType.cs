using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Enums
{
   public struct ChatType
   {
      public static int MULTIPLE_USERS { get; } = 0;
      public static int DIRECT_MSG { get; } = 1;
   }
}
