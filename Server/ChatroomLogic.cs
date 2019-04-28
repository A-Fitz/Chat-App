using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    /// <summary>
    /// Handles subscribing and unsubscribing observers from a chatroom.
    /// Also handles incoming messages and distributes it to all observers.
    /// </summary>
    class ChatroomLogic : System.IObservable<Message>, IDisposable
    {
        public static int numChatRoomsCreated { get; set; } = 0;

        public string name { get; set; }
        public int chatroomID { get; set; }

        private List<IObserver<Message>> observers;
        public List<int> RegisteredUsers { get; set; } = new List<int>();

        /// <summary>
        /// Constructor for a chatroom. Assigns a chatroomID
        /// and initializes an empty list of observers.
        /// </summary>
        public ChatroomLogic()
        {
            observers = new List<IObserver<Message>>();
            chatroomID = numChatRoomsCreated;
            numChatRoomsCreated++;
        }

        /// <summary>
        /// Every message that is specific to this chatroom with 
        /// command equal to "SEND" will pass through this function.
        /// This sends an update to the clients whom are subsribed including
        /// the sender.
        /// </summary>
        /// <param name="msg">The message to be sent to the clients</param>
        public void update(Message msg)
        {
            foreach (IObserver<Message> obs in observers)
            {
                obs.OnNext(msg);
            }
        }

        /// <summary>
        /// Subsribes an observer to this chatroom so that
        /// their OnNext() function will recieve function
        /// calls from an asynchronous thread.
        /// </summary>
        /// <param name="observer">The observer to subsribe to this chat.</param>
        /// <returns></returns>
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

        //TODO had to add this because it broke
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When the user wants to unsubsribe from the chat,
        /// they may use this IDispoable class to unsubscribe with.
        /// </summary>
        /// <typeparam name="Message"></typeparam>
        internal class Unsubscriber<Message> : IDisposable
        {
            private List<IObserver<Message>> _observers;
            private IObserver<Message> _observer;

            /// <summary>
            /// Creates an object that allows the user to unsubscribe the client from the observable.
            /// </summary>
            /// <param name="observers">Reference to the observers in the chatroom.</param>
            /// <param name="observer">The observer that subscribed.</param>
            internal Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            /// <summary>
            /// Unsubscribes the client from the observable.
            /// </summary>
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
