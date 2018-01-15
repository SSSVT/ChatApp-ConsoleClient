using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.ViewItems
{
  
    public class InputViewItem : ViewItem
    {
        public InputViewItem(string label, string value) : base(label)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override void Draw()
        {
            Console.WriteLine(this.Label + ": " + this.Value);
        }
    }
    
}
