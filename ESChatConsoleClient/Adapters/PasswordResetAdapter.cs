using ESChatConsoleClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class PasswordResetAdapter : Adapter
    {
        protected PasswordResetController PasswordResetController { get; set; }

        public PasswordResetAdapter(PasswordResetController controller)
        {
            this.PasswordResetController = controller;
        }

        public override async Task Execute(string key, string input)
        {
            throw new NotImplementedException();
        }
    }
}
