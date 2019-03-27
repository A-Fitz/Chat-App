using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
   class ChatroomLogic : System.IObservable<Message>
   {
      private static int numChatRoomsCreated = 0;
      public int chatroomID;

      private List<IObserver<Message>> observers;
      public ChatroomLogic()
      {
         observers = new List<IObserver<Message>>();
         chatroomID = numChatRoomsCreated;
         numChatRoomsCreated++;
      }


      public void update(Message msg)
      {
         foreach (IObserver<Message> obs in observers)
         {
            obs.OnNext(msg);
         }
      }

      public IDisposable Subscribe(IObserver<Message> observer)
      {
         if (!observers.Contains(observer))
         {
            lock (observers)
            {
               observers.Add(observer);
            }
            //TODO LATER: Update the client with all past history or some of it.
         }
         return new Unsubscriber<Message>(observers, observer);
      }

      internal class Unsubscriber<Message> : IDisposable
      {
         private List<IObserver<Message>> _observers;
         private IObserver<Message> _observer;

         internal Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
         {
            this._observers = observers;
            this._observer = observer;
         }

         public void Dispose()
         {
            lock (_observers)
            {
               if (_observers.Contains(_observer))
                  _observers.Remove(_observer);
            }
         }

      }
   }
}
