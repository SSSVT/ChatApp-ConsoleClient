using ESChatConsoleClient.Adapters;
using ESChatConsoleClient.Controllers;
using ESChatConsoleClient.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESChatConsoleClient
{
    public sealed class ClientEngine
    {
        public readonly FriendshipsController FriendshipsController;
        public readonly MessagesController MessagesController;
        public readonly ParticipantsController ParticipantsController;
        public readonly PasswordResetController PasswordResetController;
        public readonly RegistrationController RegistrationController;
        public readonly RoomsController RoomsController;
        public readonly TokenController TokenController;
        public readonly UsersController UsersController;

        private Stack<View> Views { get; set; } = new Stack<View>();
        private View CurrentView
        {
            get
            {
                return this.Views.Peek();
            }
        }
        public ClientEngine(string serverUrl)
        {
            this.FriendshipsController = new FriendshipsController(serverUrl, "Friendships");
            this.MessagesController = new MessagesController(serverUrl, "Messages");
            this.ParticipantsController = new ParticipantsController(serverUrl, "Participants");
            this.PasswordResetController = new PasswordResetController(serverUrl, "PasswordReset");
            this.RegistrationController = new RegistrationController(serverUrl, "Registration");
            this.RoomsController = new RoomsController(serverUrl, "Rooms");
            this.TokenController = new TokenController(serverUrl, "Token");
            this.UsersController = new UsersController(serverUrl, "Users");

            //LoggedOff or Home podle uloženýho tokenu
            this.AddView(new LoggedOffView(this));
        }

        public void Start()
        {
            while (true)
            {
                this.CurrentView.Draw();

                ConsoleKeyInfo c = Console.ReadKey(true);

                this.CurrentView.OnInput(c);
            }            
        }

        public void AddView(View view)
        {
            this.Views.Push(view);
        }

        public void PopView()
        {
            if (this.Views.Count > 1)
            {
                this.Views.Pop();
            }  
        }
    }
}
