using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.ViewItems
{
  
    public class InputViewItem : ViewItem
    {
        public string Value { get; set; } = "";

        public InputViewItem(string label, string value) : base(label)
        {
            this.Value = value;
        }

        public InputViewItem(string label) : base(label)
        {

        }

        public override void Draw()
        {
            if (this.Selected)
                Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(this.Label + ": " + this.Value);

            Console.ResetColor();
        }
    }
    
}
