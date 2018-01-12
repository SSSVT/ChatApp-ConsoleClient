using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class LoginAdapter : Adapter
    {
        #region Properties
        protected TokenController TokenController { get; set; }
        #endregion

        public LoginAdapter(TokenController controller)
        {
            this.TokenController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            input = input.Replace($"{key} ", "");

            if (Regex.IsMatch(input, "^(-U|--username) [a-zA-Z]{8,64} (-P|--password) .+$"))
            {
                Match matchUsername = Regex.Match(input, "^(-U|--username) [a-zA-Z]{8,64}");
                Match matchPassword = Regex.Match(input, "(-P|--password) .+$");

                UserCredentials credentials = new UserCredentials()
                {
                    Username = matchUsername.Value.Replace("-U ", "").Replace("--username ", ""),
                    Password = matchPassword.Value.Replace("-P ", "").Replace("--password ", "")
                };

                TokenModel token = await this.TokenController.LoginAsync(credentials);
            }
            else
            {
                throw new ArgumentException($"Login: { _InvalidParams }.");
            }
        }
    }
}
