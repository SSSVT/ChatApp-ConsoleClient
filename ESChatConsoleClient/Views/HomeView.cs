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
        private DataContext _dataContext = DataContext.GetInstance();

        public HomeView(ClientEngine clientEngine) : base(clientEngine)
        {
            this.AddViewItems(
                new MessageViewItem("Hello " + _dataContext.User.Username),
                new ActionViewItem("Rooms", () => { this.ClientEngine.AddView(new RoomsView(this.ClientEngine)); }),
                new ActionViewItem("Friends", () => { this.ClientEngine.AddView(new FriendsView(this.ClientEngine)); }),
                new ActionViewItem("Logout", () => { this.LogOut(); }));

            this.SelectViewItem(0);
        }

        private void LogOut()
        {
            _dataContext.Token = null;
            _dataContext.User = null;

            this.ClientEngine.PopView();
        }
    }
}
