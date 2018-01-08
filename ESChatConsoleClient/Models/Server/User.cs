using System;

namespace ESChatConsoleClient.Models.Server
{
    public class User : RegistrationModel
    {
        public User()
        {

        }
        public User(RegistrationModel registration)
        {
            this.FirstName = registration.FirstName;
            this.MiddleName = registration.MiddleName;
            this.LastName = registration.LastName;
            this.Birthdate = registration.Birthdate;
            this.Gender = registration.Gender;
            this.Email = registration.Email;
            this.Username = registration.Username;
        }

        public long ID { get; set; }
        public DateTime? UTCRegistrationDate { get; set; }
        /// <summary>
        /// [ADIO] - Active, Do not disturb, Invisible, Offline
        /// </summary>
        public string Status { get; set; }
    }
}
