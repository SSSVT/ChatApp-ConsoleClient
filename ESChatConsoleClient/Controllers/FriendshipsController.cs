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
    public class FriendshipsController : Controller
    {
        public FriendshipsController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<List<Friendship>> GetByUserIDAsync(long id)
        {
            //{{URL}}/api/v1/Friendships/GetByUserID/1
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Friendship>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Friendship>> GetAcceptedByUserIDAsync(long id)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetAcceptedByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Friendship>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Friendship>> GetReceivedAndPendingByUserIDAsync(long id)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"GetReceivedAndPendingByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Friendship>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Friendship> GetFriendshipAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> PostFriendshipAsync(Friendship friendship)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(friendship));

                HttpResponseMessage response = await this.HttpClient.PostAsync($"RegisterAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    //Nevrací náhodou token?
                    return JsonConvert.DeserializeObject<Friendship>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Friendship> PutFriendshipAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Friendship> DeleteFriendshipAsync()
        {
            throw new NotImplementedException();
        }
    }
}
