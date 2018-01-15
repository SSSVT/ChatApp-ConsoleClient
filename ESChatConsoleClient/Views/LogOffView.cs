using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class LogOffView : View
    {
        public LogOffView()
        {            
            this.AddViewItems(
                new ActionViewItem("Login", () => { }),
                new ActionViewItem("Register", () => { }));
        }
    }
}
