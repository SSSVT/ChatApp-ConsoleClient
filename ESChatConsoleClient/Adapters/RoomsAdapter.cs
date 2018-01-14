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

            string findMatchPattern = "(-f|--find) ([0-9]+)";
            string findAllMatchPattern = "(-F|--find-all)";
            string findByUserIDMatchPattern = "(--find-by-user-id) ([0-9]+)";
            string createMatchPattern = "(-C|--create) ";
            string updateMatchPattern = "(-U|--update) ";
            string deleteMatchPattern = "(-D|--delete) ";

            throw new NotImplementedException();
        }
    }
}
