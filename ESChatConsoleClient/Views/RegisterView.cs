using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class RegisterView : View
    {
        public RegisterView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.AddViewItems(
                            new InputViewItem("Username", ""),
                            new InputViewItem("Password", ""),
                            new ActionViewItem("Register", () => { }));

            this.SelectViewItem(0);
        }
    }
}
