using ESChatConsoleClient.Data;
using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public abstract class SecuredController : Controller
    {
        public SecuredController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        protected void SetAuthorizationHeader()
        {
            TokenModel token = DataContext.GetInstance().Token;

            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Type, token.Token);
        }
    }
}
