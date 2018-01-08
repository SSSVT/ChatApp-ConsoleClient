using ESChatConsoleClient.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class ParticipantsController : Controller
    {
        public ParticipantsController(string serverUrl) : base(serverUrl)
        {
        }

        public async Task<Participant> GetByUserIDAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Participant> GetByRoomIDAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Participant> PostParticipantAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Participant> DeleteParticipantAsync()
        {
            throw new NotImplementedException();
        }
    }
}
