using System;
using Newtonsoft.Json;

namespace ESChatConsoleClient.Models.Server
{
    public class Room
    {
        public long ID { get; set; }
        public long IDOwner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UTCCreationDate { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
