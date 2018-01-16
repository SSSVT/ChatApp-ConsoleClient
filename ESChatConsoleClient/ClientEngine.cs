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
            //LoggedOff or Home podle uloženýho tokenu
            this.AddView(new LoggedOffView(this));
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
