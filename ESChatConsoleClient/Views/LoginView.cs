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
        public LoginView()
        {
            this.AddViewItems(
                            new InputViewItem("Login", ""),
                            new InputViewItem("Register", ""));
        }        
    }
}
