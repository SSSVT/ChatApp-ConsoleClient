using ESChatConsoleClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESChatConsoleClient
{
    public sealed class ClientEngine
    {
        #region Fields
        private readonly FriendshipsController _friendshipsController;
        private readonly MessagesController _messagesController;
        private readonly ParticipantsController _participantsController;
        private readonly PasswordResetController _passwordResetController;
        private readonly RegistrationController _registrationController;
        private readonly RoomsController _roomsController;
        private readonly TokenController _tokenController;
        private readonly UsersController _usersController;
        #endregion

        public ClientEngine(string serverUrl)
        {
            this._friendshipsController = new FriendshipsController(serverUrl, "Friendships");
            this._messagesController = new MessagesController(serverUrl, "Messages");
            this._participantsController = new ParticipantsController(serverUrl, "Participants");
            this._passwordResetController = new PasswordResetController(serverUrl, "PasswordReset");
            this._registrationController = new RegistrationController(serverUrl, "Registration");
            this._roomsController = new RoomsController(serverUrl, "Rooms");
            this._tokenController = new TokenController(serverUrl, "Token");
            this._usersController = new UsersController(serverUrl, "Users");
        }

        public async Task StartAsync()
        {
            Console.WriteLine(await this.IsUsernameAvailableAsync("fam299"));

            while (true)
            {
                string userInput = Console.ReadLine();

                switch (userInput.Split(new char[] { ' ' })[0])
                {
                    case "login":
                        userInput.Replace("login ", "");
                        await this.LoginAsync(userInput);
                        break;
                    case "help":
                        break;
                    default:
                        break;
                }
            }
        }

        private async Task LoginAsync(string userInput)
        {
            //Regex.Match("", "").Value;

            throw new NotImplementedException();
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            return await this._registrationController.IsUsernameAvailableAsync(username);
        }
    }
}
