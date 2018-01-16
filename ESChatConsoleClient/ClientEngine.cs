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
        #region Fields
        //private readonly FriendshipsAdapter _friendshipsAdapter;
        //private readonly MessagesAdapter _messagesAdapter;
        //private readonly ParticipantsAdapter _participantsAdapter;
        //private readonly PasswordResetAdapter _passwordResetAdapter;

        //private readonly RegistrationAdapter _registrationAdapter;
        //private readonly RoomsAdapter _roomsAdapter;
        //private readonly LoginAdapter _loginAdapter;
        //private readonly UsersAdapter _usersAdapter;

        private Stack<View> Views { get; set; } = new Stack<View>();
        private View CurrentView
        {
            get
            {
                return this.Views.Peek();
            }
        }
        #endregion

        public ClientEngine(string serverUrl)
        {
            //LoggedOff or Home podle uloženýho tokenu
            LoggedOffView loggedOffView = new LoggedOffView(this);
            this.Views.Push(loggedOffView);
        }

        public void Start()
        {
            while (true)
            {
                this.CurrentView.Draw();

                ConsoleKeyInfo c = Console.ReadKey();

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
