using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.ViewItems
{
    public class MessageViewItem : ViewItem
    {
        public MessageViewItem(string label) : base(label)
        {
        }

        public override void Draw()
        {
            Console.WriteLine(this.Label);
        }
    }
}
