using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.ViewItems
{
    public class ActionViewItem : ViewItem
    {
        public ActionViewItem(string label, Action action) : base(label)
        {
            this.Action = action;
        }

        public Action Action { get; set; }

        public void Execute()
        {
            Action.Invoke();
        }

        public override void Draw()
        {
            if (this.Selected)
               Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(this.Label);

            Console.ResetColor();
        }
    }
}
