using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class RoomsAdapter : Adapter
    {
        protected RoomsController RoomsController { get; set; }

        public RoomsAdapter(RoomsController controller)
        {
            this.RoomsController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = this.RemoveCommand(key, input);

            throw new NotImplementedException();
        }
    }
}
