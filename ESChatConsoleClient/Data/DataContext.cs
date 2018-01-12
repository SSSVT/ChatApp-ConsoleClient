using ESChatConsoleClient.Models.Server;
using System.Collections.Concurrent;
using System.Linq;

namespace ESChatConsoleClient.Data
{
    //Náhrada za database - drží všechna data
    public class DataContext
    {
        #region Singleton
        protected DataContext()
        {
            this.Friendships = new ConcurrentBag<Friendship>();
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
        public ConcurrentBag<TokenModel> Tokens { get; set; }

        public TokenModel GetLastToken()
        {
            return this.Tokens.OrderByDescending(x => x.Expiration).FirstOrDefault();
        }
    }
}
