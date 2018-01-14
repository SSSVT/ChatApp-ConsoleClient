using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class PasswordResetController : SecuredController
    {
        public PasswordResetController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
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
