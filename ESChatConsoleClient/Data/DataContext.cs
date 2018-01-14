using ESChatConsoleClient.Models.Server;
using System.Collections.Concurrent;

namespace ESChatConsoleClient.Data
{
    //Náhrada za database - drží všechna data
    public class DataContext
    {
        #region Singleton
        protected DataContext()
        {
            this.Friendships = new ConcurrentBag<Friendship>();
            this.Messages = new ConcurrentBag<Message>();
            this.Participant = new ConcurrentBag<Participant>();
            this.Rooms = new ConcurrentBag<Room>();
            this.Users = new ConcurrentBag<User>();
        }
        public static DataContext _Instance { get; set; }
        public static DataContext GetInstance()
        {
            if (DataContext._Instance == null)
                DataContext._Instance = new DataContext();
            return DataContext._Instance;
        }
        #endregion

        public ConcurrentBag<Friendship> Friendships { get; set; }
        public ConcurrentBag<Message> Messages { get; set; }
        public ConcurrentBag<Participant> Participant { get; set; }
        public ConcurrentBag<Room> Rooms { get; set; }
        public ConcurrentBag<User> Users { get; set; }

        #region CurrentUser
        protected object CurrentUserLock = new object();
        protected User _User;
        public User User
        {
            get
            {
                lock (CurrentUserLock)
                {
                    return _User;
                }
            }
            set
            {
                lock (CurrentUserLock)
                {
                    _User = value;
                }
            }
        }
        #endregion

        #region Token
        protected object TokenLock = new object();
        protected TokenModel _Token;
        public TokenModel Token
        {
            get
            {
                lock (TokenLock)
                {
                    return _Token;
                }
            }
            set
            {
                lock (TokenLock)
                {
                    _Token = value;
                }
            }
        }
        #endregion
    }
}
