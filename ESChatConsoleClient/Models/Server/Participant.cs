using System;

namespace ESChatConsoleClient.Models.Server
{
    public class Participant
    {
        public Guid ID { get; set; }
        public long IDRoom { get; set; }
        public long IDUser { get; set; }
    }
}
