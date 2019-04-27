using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   public abstract class UndoCommand : Command
   {
      public abstract void Undo();
   }
}
