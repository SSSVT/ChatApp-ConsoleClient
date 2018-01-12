using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class FriendshipsAdapter : Adapter
    {
        protected FriendshipsController FriendshipsController { get; set; }

        public FriendshipsAdapter(FriendshipsController controller)
        {
            this.FriendshipsController = controller;
        }

        public override Task Execute(string key, string input)
        {
            input = input.Replace($"{key} ", "");
            if (Regex.IsMatch(input, "^(-F|--find|-A|--add|-R|--remove) [a-zA-Z]{8,64}$"))
            {
                throw new NotImplementedException();
            }
            else
            {
                Console.WriteLine($"Friendships: { _InvalidParams }.");
            }

            throw new NotImplementedException();
        }
    }
}
