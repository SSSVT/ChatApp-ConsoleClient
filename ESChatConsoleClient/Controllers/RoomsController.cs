using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class RoomsController : Controller
    {
        public RoomsController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<Room> FindAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> FindByUserIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> CreateAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
