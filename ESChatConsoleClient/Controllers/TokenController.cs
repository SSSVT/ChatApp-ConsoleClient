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
    public class TokenController : Controller
    {
        public TokenController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<TokenModel> LoginAsync(UserCredentials login)
        {
            //TODO: https://stackoverflow.com/questions/35344981/posting-to-a-web-api-using-httpclient-and-web-api-method-frombody-parameter-en
            //await this.HttpClient.PostAsync("", new FormUrlEncodedContent());
            //throw new NotImplementedException();

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(login));

                HttpResponseMessage response = await this.HttpClient.PostAsync($"LoginAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    //Nevrací náhodou token?
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
