using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class FriendshipsController : Controller
    {
        public FriendshipsController(string serverUrl) : base(serverUrl)
        {
        }

        public async Task<Friendship> GetByUserIDAsync(long id)
        {
            //{{URL}}/api/v1/Friendships/GetByUserID/1
            throw new NotImplementedException();
        }

        public async Task<Friendship> GetAcceptedByUserIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> GetReceivedAndPendingByUserIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> GetFriendshipAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> PostFriendshipAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> PutFriendshipAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> DeleteFriendshipAsync()
        {
            throw new NotImplementedException();
        }
    }
}
