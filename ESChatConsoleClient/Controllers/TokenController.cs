using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class TokenController : Controller
    {
        public TokenController(string serverUrl) : base(serverUrl)
        {
        }

        public async Task<TokenModel> LoginAsync(UserCredentials login)
        {
            throw new NotImplementedException();
        }
    }
}
