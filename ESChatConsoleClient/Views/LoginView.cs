using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Data;
using ESChatConsoleClient.Models.Server;
using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class LoginView : View
    {
        private InputViewItem usernameInput = new InputViewItem("Username");
        private InputViewItem passwordInput = new PasswordInputViewItem("Password");

        private ActionViewItem loginAction;

        public LoginView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.loginAction = new ActionViewItem("Login", () => { this.Login(); });

            this.AddViewItems(
                            this.usernameInput,
                            this.passwordInput,
                            this.loginAction
                            );

            this.SelectViewItem(0);
        }

        private async void Login()
        {
            UserCredentials credentials = new UserCredentials()
            {
                Username = usernameInput.Value,
                Password = passwordInput.Value
            };

            try
            {
                TokenModel token = await this.ClientEngine.TokenController.LoginAsync(credentials);
                DataContext.GetInstance().Token = token;
                User user = await this.ClientEngine.UsersController.GetCurrentUserAsync();
                DataContext.GetInstance().User = user;

                this.ClientEngine.AddView(new HomeView(this.ClientEngine));
            }
            catch (Exception e)
            {

            }          
        }
    }
}
