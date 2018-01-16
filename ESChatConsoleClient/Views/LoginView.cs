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
        public LoginView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.AddViewItems(
                            new InputViewItem("Username", ""),
                            new InputViewItem("Password", ""),
                            new ActionViewItem("Login",() => { }));

            this.SelectViewItem(0);
        }        
    }
}
