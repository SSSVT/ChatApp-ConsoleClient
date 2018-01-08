using System;

namespace ESChatConsoleClient.Models.Server
{
    public class Room
    {
        public long ID { get; set; }
        public long IDOwner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UTCCreationDate { get; set; }
    }
}
