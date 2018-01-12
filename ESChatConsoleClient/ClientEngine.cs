using ESChatConsoleClient.Adapters;
using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Models.Server;
using System;
using System.Threading.Tasks;

namespace ESChatConsoleClient
{
    public sealed class ClientEngine
    {
        #region Fields
        //Máš toto
        private readonly FriendshipsAdapter _friendshipsAdapter;
        private readonly MessagesAdapter _messagesAdapter;
        private readonly ParticipantsAdapter _participantsAdapter;
        private readonly PasswordResetAdapter _passwordResetAdapter;

        //Beru si toto
        private readonly RegistrationAdapter _registrationAdapter;
        private readonly RoomsAdapter _roomsAdapter;
        private readonly LoginAdapter _loginAdapter;
        private readonly UsersAdapter _usersAdapter;
        #endregion

        public ClientEngine(string serverUrl)
        {
            this._friendshipsAdapter = new FriendshipsAdapter(new FriendshipsController(serverUrl, "Friendships"));
            this._messagesAdapter = new MessagesAdapter(new MessagesController(serverUrl, "Messages"));
            this._participantsAdapter = new ParticipantsAdapter(new ParticipantsController(serverUrl, "Participants"));
            this._passwordResetAdapter = new PasswordResetAdapter(new PasswordResetController(serverUrl, "PasswordReset"));
            this._registrationAdapter = new RegistrationAdapter(new RegistrationController(serverUrl, "Registration"));
            this._roomsAdapter = new RoomsAdapter(new RoomsController(serverUrl, "Rooms"));
            this._loginAdapter = new LoginAdapter(new TokenController(serverUrl, "Token"));
            this._usersAdapter = new UsersAdapter(new UsersController(serverUrl, "Users"));
        }

        public async Task StartAsync()
        {
            //Console.WriteLine(await this.IsUsernameAvailableAsync("fam299"));

            while (true)
            {
                string userInput = Console.ReadLine();

                string key = userInput.Split(new char[] { ' ' })[0];
                string strKey = key.ToLower();

                try
                {
                    switch (strKey)
                    {
                        case "friend":
                            await this._friendshipsAdapter.Execute(key, userInput);
                            throw new NotImplementedException();
                            break;
                        
                        case "participants":
                            throw new NotImplementedException();
                            break;

                        case "passwordreset":
                            throw new NotImplementedException();
                            break;

                        case "registration":
                            throw new NotImplementedException();
                            break;

                        case "rooms":
                            throw new NotImplementedException();
                            break;

                        case "login":
                            await this._loginAdapter.Execute(key, userInput);
                            throw new NotImplementedException();
                            break;

                        case "users":
                            throw new NotImplementedException();
                            break;

                        default:
                            Console.WriteLine("Message wrote");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Save exception
                    Console.WriteLine(ex.Message);
                }                
            }
        }
    }
}
