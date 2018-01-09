using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class MessagesController : Controller
    {
        public MessagesController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<Message> GetByUserIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Message> GetByRoomIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Message> CreateAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
