using ESChatConsoleClient.Data;
using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class HomeView : View
    {
        public HomeView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.AddViewItems(new ActionViewItem("Hello", () => { }));

            this.SelectViewItem(0);
        }
    }
}
