using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController(string serverUrl) : base(serverUrl)
        {
        }

        public async Task<User> RegisterAsync(RegistrationModel registration)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
