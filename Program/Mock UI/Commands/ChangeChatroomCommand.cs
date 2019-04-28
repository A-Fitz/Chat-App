using ChatApp;
using System.Windows.Forms;

namespace Mock_UI
{
   /// <summary>
   /// Concrete implementation of an UndoCommand for changing the chatroom.
   /// </summary>
   class ChangeChatroomCommand : UndoCommand
   {
      private ListBox chatroomListBox, chatListBox;
      private object previousSelectedItem;

      /// <summary>
      /// Changes the chatroom displayed in the message list box and saves the previously selected chatroom for undo-ing.
      /// </summary>
      /// <param name="chatroomListBox">The list of chatrooms</param>
      /// <param name="chatListBox">The list of chat messages for a chatroom</param>
      /// <param name="selectedChatroomInListBox">The newly selected chatroom</param>
      public ChangeChatroomCommand(ListBox chatroomListBox, ListBox chatListBox, object selectedChatroomInListBox)
      {
         this.chatroomListBox = chatroomListBox;
         this.chatListBox = chatListBox;
         this.previousSelectedItem = selectedChatroomInListBox;
      }

      /// <summary>
      /// Clear the list of messages and populate the list with messages from the newly selected chatroom.
      /// </summary>
      public override void Execute()
      {
         chatListBox.Items.Clear();
         populateChatListBox((Chatroom)(chatroomListBox.SelectedItem));
      }

      /// <summary>
      /// Clear the list of messages, populate the list of messages from the previously selected chatroom, and show
      /// the previously selected chatroom as selected in the chatroom list.
      /// </summary>
      public override void Undo()
      {
         chatListBox.Items.Clear();
         populateChatListBox((Chatroom)(previousSelectedItem));
         chatroomListBox.SetSelected(chatroomListBox.Items.IndexOf(previousSelectedItem), true);
      }

      /// <summary>
      /// Add each message from a specified chatroom to the message list.
      /// </summary>
      /// <param name="room">The selected chatroom</param>
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
