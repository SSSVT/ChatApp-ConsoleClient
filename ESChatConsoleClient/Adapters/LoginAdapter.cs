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
            input = this.RemoveCommand(key, input);

            string userMatchPattern = "[a-zA-Z0-9]{4,64}";
            string passMatchPattern = ".+";

            if (Regex.IsMatch(input, $"^(-U|--username) {userMatchPattern} (-P|--password) {passMatchPattern}$"))
            {
                Match matchUsername = Regex.Match(input, $"^(-U|--username) {userMatchPattern}");
                Match matchPassword = Regex.Match(input, $"(-P|--password) {passMatchPattern}$");

                UserCredentials credentials = new UserCredentials()
                {
                    Username = matchUsername.Value.Replace("-U ", "").Replace("--username ", ""),
                    Password = matchPassword.Value.Replace("-P ", "").Replace("--password ", "")
                };

                TokenModel token = await this.TokenController.LoginAsync(credentials);
                this.DataContext.Token = token;
            }
            else
            {
                throw new ArgumentException($"Login: { _InvalidParams }.");
            }
        }
    }
}
