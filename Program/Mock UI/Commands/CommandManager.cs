using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_UI
{
   /// <summary>
   /// A class that handles all types of commands, executes all commands. Stores specific command types on the Stack for undo-ing.
   /// </summary>
   class CommandManager
   {
      private Stack commandStack = new Stack();

      /// <summary>
      /// Executes a command by calling its execute method. If the command is type UndoCommand then push it on the stack also.
      /// </summary>
      /// <param name="cmd"></param>
      public void ExecuteCommand(Command cmd)
      {
         cmd.Execute();

         if(cmd is UndoCommand)
         {
            commandStack.Push(cmd);
         }
      }

      /// <summary>
      /// Used for undo-ing a command. Pops from the stack and calls the undo method of the popped command.
      /// </summary>
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
