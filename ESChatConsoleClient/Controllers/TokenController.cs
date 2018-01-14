using ESChatConsoleClient.Models.Server;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Controllers
{
    public class TokenController : Controller
    {
        public TokenController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<TokenModel> LoginAsync(UserCredentials login)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"LoginAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TokenModel>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
