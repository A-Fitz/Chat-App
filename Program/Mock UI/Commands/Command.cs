using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   /// <summary>
   /// Abstract class for a command. All commands need to execute.
   /// </summary>
   public abstract class Command
   {
      /// <summary>
      /// Execute the concrete command in a specified manner.
      /// </summary>
      public abstract void Execute();
   }
}
