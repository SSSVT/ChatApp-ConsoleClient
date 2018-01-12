using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class ParticipantsAdapter : Adapter
    {
        public ParticipantsController ParticipantsController { get; set; }

        public ParticipantsAdapter(ParticipantsController controller)
        {
            this.ParticipantsController = controller;
        }

        public override Task Execute(string key, string input)
        {
            throw new NotImplementedException();
        }
    }
}
