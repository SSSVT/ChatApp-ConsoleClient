using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class RoomsView : View
    {
        public RoomsView(ClientEngine clientEngine) : base(clientEngine)
        {
            //TODO: Display Rooms
            this.AddViewItems(
                new ActionViewItem("Create", () => { }));

            this.SelectViewItem(0);
        }
    }
}
