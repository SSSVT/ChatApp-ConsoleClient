using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class LoggedOffView : View
    {
        public LoggedOffView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.AddViewItems(
                new ActionViewItem("Login", () => { clientEngine.AddView(new LoginView(clientEngine)); }),
                new ActionViewItem("Register", () => { clientEngine.AddView(new RegisterView(clientEngine)); }),
                new ActionViewItem("Close", () => { Environment.Exit(0); }));

            this.SelectViewItem(0);
        }
    }
}
