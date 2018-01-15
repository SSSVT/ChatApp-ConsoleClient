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

        protected ViewItem SelectedViewItem { get; set; }

        public void Start()
        {
            this.Draw();

            while (true)
            {
                
            }
        }

        protected void Draw()
        {
            Console.Clear();

            foreach (ViewItem item in this.viewItems)
            {
                item.Draw();
            }
        }

        protected void AddViewItems(params ViewItem[] items)
        {
            foreach (ViewItem item in items)
            {
                this.viewItems.Add(item);
            }
        }

        protected void SelectViewItem(int index)
        {
            if (SelectedViewItem != null)
            {
                this.SelectedViewItem.Selected = false;
            }

            this.SelectedViewItem = this.viewItems[index];
            this.SelectedViewItem.Selected = true;
        }

        public void KeyDown()
        {

        }

        public void KeyUp()
        {

        }
    }
}
