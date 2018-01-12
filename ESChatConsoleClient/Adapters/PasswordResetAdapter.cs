using ESChatConsoleClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public class PasswordResetAdapter
    {
        protected PasswordResetController PasswordResetController { get; set; }

        public PasswordResetAdapter(PasswordResetController controller)
        {
            this.PasswordResetController = controller;
        }
    }
}
