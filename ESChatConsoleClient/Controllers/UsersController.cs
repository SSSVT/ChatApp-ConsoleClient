using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(string serverUrl) : base(serverUrl)
        {
        }

        public async Task<User> GetCurrentUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> SearchForUsersByUsernameAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByUsernameAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> DetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
