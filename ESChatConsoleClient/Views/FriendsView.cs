using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class FriendsView : View
    {
        public FriendsView(ClientEngine clientEngine) : base(clientEngine)
        {

            //TODO: Display Friends
            this.AddViewItems(
                new ActionViewItem("Add", () => { this.ClientEngine.AddView(new AddFriendView(this.ClientEngine)); }));

            this.SelectViewItem(0);
        }
    }
}
