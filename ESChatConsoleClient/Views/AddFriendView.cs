using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public class AddFriendView : View
    {
        public AddFriendView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.AddViewItems(
            new InputViewItem("Username"),
            new ActionViewItem("Add", () => { this.AddFriend(); }));

            this.SelectViewItem(0);
        }

        private void AddFriend()
        {
            throw new NotImplementedException();
        }
    }
}
