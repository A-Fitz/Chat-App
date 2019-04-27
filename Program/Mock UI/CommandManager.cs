using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   class CommandManager
   {
      private Stack commandStack = new Stack();

      public void ExecuteCommand(Command cmd)
      {
         cmd.Execute();

         if(cmd is UndoCommand)
         {
            commandStack.Push(cmd);
         }
      }

      public void Undo()
      {
         if (commandStack.Count > 0)
         {
            UndoCommand cmd = (UndoCommand)commandStack.Pop();
            cmd.Undo();
         }
      }
   }
}
