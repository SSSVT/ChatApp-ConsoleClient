using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class RegistrationAdapter : Adapter
    {
        protected RegistrationController RegistrationController { get; set; }

        public RegistrationAdapter(RegistrationController controller)
        {
            this.RegistrationController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = input.Replace($"{key} ", "");

            if (Regex.IsMatch(input, ""))
            {

            }

            RegistrationModel registration = new RegistrationModel()
            {
                
            };

            User user = await this.RegistrationController.RegisterAsync(registration);

            throw new NotImplementedException();
        }
    }
}
