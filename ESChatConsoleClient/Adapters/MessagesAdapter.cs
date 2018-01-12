using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class MessagesAdapter : Adapter
    {
        protected MessagesController MessagesController { get; set; }

        public MessagesAdapter(MessagesController controller)
        {
            this.MessagesController = controller;
        }

        public override Task Execute(string key, string input)
        {
            throw new NotImplementedException();
        }
    }
}
