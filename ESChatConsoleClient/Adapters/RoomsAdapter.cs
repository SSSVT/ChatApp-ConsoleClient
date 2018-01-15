using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public partial class RoomsAdapter : Adapter
    {
        protected RoomsController RoomsController { get; set; }

        public RoomsAdapter(RoomsController controller)
        {
            this.RoomsController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = this.RemoveCommand(key, input);

            string idMatchPattern = "([0-9]+)";
            string txtMatchPattern = "([A-Za-z0-9]+)";

            string findMatchPattern = $"((-f|--find) {idMatchPattern}$)";
            string findAllMatchPattern = $"((-F|--find-all))";
            string findByUserIDMatchPattern = $"((--find-by-user-id) {idMatchPattern}$)";

            string selectMatchPattern = $"((-S|--select) {idMatchPattern})";

            string createMatchPattern = $"((-C|--create) (-N|--name) {txtMatchPattern} (-D|--description) {txtMatchPattern}$)";
            string updateMatchPattern = $"((-U|--update) (-I|--id) {idMatchPattern} (-N|--name) {txtMatchPattern} (-D|--description) {txtMatchPattern}$)";
            string deleteMatchPattern = $"((-D|--delete) {idMatchPattern}$)";

            if (Regex.IsMatch(input, findMatchPattern))
            {
                Match match = Regex.Match(input, idMatchPattern);
                long id = Convert.ToInt64(match.Value);
                Room room = await this.RoomsController.FindAsync(id);
                this.Print(room);
            }
            else if (Regex.IsMatch(input, findAllMatchPattern))
            {
                ICollection<Room> rooms = await this.RoomsController.FindAllAsync();
                this.Print(rooms);
            }
            else if (Regex.IsMatch(input, findByUserIDMatchPattern))
            {
                Match match = Regex.Match(input, idMatchPattern);
                long id = Convert.ToInt64(match.Value);
                List<Room> rooms = await this.RoomsController.FindByUserIDAsync(id);
                this.Print(rooms);
            }
            else if (Regex.IsMatch(input, selectMatchPattern))
            {
                Match match = Regex.Match(input, idMatchPattern);
                long id = Convert.ToInt64(match.Value);
                this.DataContext.SetActiveRoom(id);
            }
            else if (Regex.IsMatch(input, createMatchPattern))
            {
                string name = Regex.Match(input, $"(-N|--name) {txtMatchPattern}").Value.Replace("-N ", "").Replace("--name ", "");
                string desc = Regex.Match(input, $"(-D|--description) {txtMatchPattern}").Value.Replace("-D ", "").Replace("--description ", "");

                Room room = new Room()
                {
                    Name = name,
                    Description = desc,
                    IDOwner = this.DataContext.User.ID
                };

                room = await this.RoomsController.CreateAsync(room);
                this.DataContext.Rooms.Add(room);
                this.Print(room);
            }
            else if (Regex.IsMatch(input, updateMatchPattern))
            {
                string name = Regex.Match(input, $"(-N|--name) {txtMatchPattern}").Value.Replace("-N ", "").Replace("--name ", "");
                string desc = Regex.Match(input, $"(-D|--description) {txtMatchPattern}").Value.Replace("-D ", "").Replace("--description ", "");
                string txtId = Regex.Match(input, $"(-I|--id) {idMatchPattern}").Value.Replace("-I ", "").Replace("--id ", "");
                long id = Convert.ToInt64(txtId);

                Room room = this.DataContext.Rooms.Where(x => x.ID == id).FirstOrDefault();
                room.Name = name;
                room.Description = deleteMatchPattern;

                await this.RoomsController.UpdateAsync(room);
                this.Print(room);
            }
            else if (Regex.IsMatch(input, deleteMatchPattern))
            {
                Match match = Regex.Match(input, idMatchPattern);
                long id = Convert.ToInt64(match.Value);
                Room room = await this.RoomsController.DeleteAsync(id);
                this.Print(room);
            }
        }
    }

    public partial class RoomsAdapter
    {
        public void Print(ICollection<Room> rooms)
        {
            foreach (Room item in rooms)
            {
                Console.WriteLine($"\t{ item.ID }\t{item.Name}\t{item.Description}");
            }
        }
        public void Print(Room room)
        {
            Console.WriteLine($"\t{ room.ID }\t{room.Name}\t{room.Description}");
        }
    }
}
