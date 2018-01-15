using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public partial class MessagesAdapter : Adapter
    {
        protected MessagesController MessagesController { get; set; }

        public MessagesAdapter(MessagesController controller)
        {
            this.MessagesController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = this.RemoveCommand(key, input);

            if (this.DataContext.GetActiveRoom != null)
            {
                string idMatchPattern = "([0-9]+)";
                string txtMatchPattern = @"(\w+)";

                string content = Regex.Match(input, $"(-C|--content) {txtMatchPattern}").Value.Replace("-C ", "").Replace("--content ", "");
                string txtId = Regex.Match(input, $"(-I|--room-id) {idMatchPattern}").Value.Replace("-I ", "").Replace("--room-id ", "");
                long id = Convert.ToInt64(txtId);

                Message message = new Message()
                {
                    Content = content,
                    IDUser = this.DataContext.User.ID,
                    IDRoom = id,
                    UTCSend = DateTime.UtcNow
                };

                await this.MessagesController.CreateAsync(message);
                this.DataContext.Messages.Add(message);
                this.Print(message);
            }
            else
            {
                Console.WriteLine("Unknown command");
            }

            /*
            string findByRoomIDMatchPattern = $"(-F|--find-by-room-id) {idMatchPattern}";
            string findByUserIDMatchPattern = $"(--find-by-user-id) {idMatchPattern}";
            string createMatchPattern = $"(-C|--create) (-I|--room-id) {idMatchPattern} (-C|--content) {txtMatchPattern} ";

            if (Regex.IsMatch(input, findByRoomIDMatchPattern))
            {
                Match match = Regex.Match(input, idMatchPattern);
                long id = Convert.ToInt64(match.Value);
                List<Message> messages = await this.MessagesController.GetByRoomIDAsync(id);
                this.Print(messages);
            }
            else if (Regex.IsMatch(input, findByUserIDMatchPattern))
            {
                Match match = Regex.Match(input, idMatchPattern);
                long id = Convert.ToInt64(match.Value);
                List<Message> messages = await this.MessagesController.GetByUserIDAsync(id);
                this.Print(messages);
            }
            else if (Regex.IsMatch(input, createMatchPattern))
            {

            }
            */
        }

    }
    public partial class MessagesAdapter
    {
        public void Print(ICollection<Message> messages)
        {
            foreach (Message item in messages)
            {
                Console.WriteLine($"\t{ item.IDUser }\t{item.Content}");
            }
        }
        public void Print(Message message)
        {
            Console.WriteLine($"\t{ message.IDUser }\t{message.Content}");
        }
    }
}
