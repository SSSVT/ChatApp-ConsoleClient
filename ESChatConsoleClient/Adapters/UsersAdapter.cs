using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class UsersAdapter : Adapter
    {
        protected UsersController UsersController { get; set; }

        public UsersAdapter(UsersController controller)
        {
            this.UsersController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = this.RemoveCommand(key, input);

            throw new NotImplementedException();
        }
    }
}
