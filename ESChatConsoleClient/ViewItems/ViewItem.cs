using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.ViewItems
{
    public abstract class ViewItem : IDrawable
    {
        public ViewItem(string label)
        {
            this.Label = label;
        }
        public string Label { get; set; }

        public bool Selected { get; set; }
        public abstract void Draw();
    }
}
