using ChatApp;
using System.Windows.Forms;

namespace Mock_UI
{
   class ChangeChatroomCommand : UndoCommand
   {
      private ListBox chatroomListBox, chatListBox;
      private object previousSelectedItem;

      public ChangeChatroomCommand(ListBox chatroomListBox, ListBox chatListBox, object selectedChatroomInListBox)
      {
         this.chatroomListBox = chatroomListBox;
         this.chatListBox = chatListBox;
         this.previousSelectedItem = selectedChatroomInListBox;
      }

      public override void Execute()
      {
         chatListBox.Items.Clear();
         populateChatListBox((Chatroom)(chatroomListBox.SelectedItem));
      }

      public override void Undo()
      {
         chatListBox.Items.Clear();
         populateChatListBox((Chatroom)(previousSelectedItem));
         chatroomListBox.SetSelected(chatroomListBox.Items.IndexOf(previousSelectedItem), true);
      }

      private void populateChatListBox(Chatroom room)
      {
         foreach (TCPMessage t in room.messages)
         {
            chatListBox.Items.Add(t.message);
            chatListBox.SelectedIndex = chatListBox.Items.Count - 1;
            chatListBox.SelectedIndex = -1;
         }
      }
   }


}
