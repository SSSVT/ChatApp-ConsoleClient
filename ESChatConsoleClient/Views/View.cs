using ESChatConsoleClient.ViewItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Views
{
    public abstract class View
    {
        protected List<ViewItem> viewItems = new List<ViewItem>();
        public void Start()
        {
            while (true)
            {
                this.Draw();
            }
        }

        public void Draw()
        {
            foreach (ViewItem item in this.viewItems)
            {
                item.Draw();
            }
        }

        public void AddViewItems(params ViewItem[] items)
        {
            foreach (ViewItem item in items)
            {
                this.viewItems.Add(item);
            }
        }
    }
}
