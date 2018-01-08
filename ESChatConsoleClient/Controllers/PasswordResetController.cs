using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class PasswordResetController : Controller
    {
        public PasswordResetController(string serverUrl) : base(serverUrl)
        {
        }

        public async Task ForgotPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ResetPasswordAsync()
        {
            throw new NotImplementedException();
        }
    }
}
