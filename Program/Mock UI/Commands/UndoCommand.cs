using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   /// <summary>
   /// Abstract class for an UndoCommand. It must contain an execute function and an undo function.
   /// </summary>
   public abstract class UndoCommand : Command
   {
      /// <summary>
      /// Undo the last execution.
      /// </summary>
      public abstract void Undo();
   }
}
