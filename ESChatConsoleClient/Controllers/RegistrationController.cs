using ESChatConsoleClient.Models.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<User> RegisterAsync(RegistrationModel registration)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(registration));

                HttpResponseMessage response = await this.HttpClient.PostAsync($"RegisterAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"IsUsernameAvailableAsync/{username}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return Convert.ToBoolean(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                //TODO: Save exception ServerConnectionException
                throw;
            }
        }
    }
}
