using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.ViewItems
{
    public class PasswordInputViewItem : InputViewItem
    {

        public char PasswordChar { get; set; } = '*';
        public PasswordInputViewItem(string label, string value) : base(label, value)
        {
        }
        public PasswordInputViewItem(string label) : base(label)
        {
        }

        public override void Draw()
        {
            if (this.Selected)
                Console.BackgroundColor = ConsoleColor.DarkBlue;

            string passwordChars = string.Empty.PadLeft(this.Value.Length, this.PasswordChar);

            Console.WriteLine(this.Label + ": " + passwordChars);

            Console.ResetColor();
        }
    }
}
