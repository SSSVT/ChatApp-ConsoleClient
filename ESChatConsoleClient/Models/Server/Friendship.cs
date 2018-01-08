using System;

namespace ESChatConsoleClient.Models.Server
{
    public class Friendship
    {
        public Guid ID { get; set; }
        public long IDSender { get; set; }
        public long IDRecipient { get; set; }
        public DateTime? UTCServerReceived { get; set; }
        public DateTime? UTCAccepted { get; set; }

        #region Virtual
        public virtual User Sender { get; set; }
        public virtual User Recipient { get; set; }
        #endregion
    }
}
