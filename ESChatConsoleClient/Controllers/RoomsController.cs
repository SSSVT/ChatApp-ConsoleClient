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
    public class RoomsController : Controller
    {
        public RoomsController(string serverUrl, string controllerName) : base(serverUrl, controllerName)
        {
        }

        public async Task<Room> FindAsync(long id)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"FindAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Room>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Room> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Room>> FindByUserIDAsync(long id)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.GetAsync($"FindByUserIDAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Room>>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Room> CreateAsync(Room room)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PostAsync($"CreateAsync", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Room>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Room room)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.HttpClient.PutAsync($"UpdateAsync/{room.ID}", content);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return;

                    //string responseContent = await response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<Room>(responseContent);
                }

                throw new HttpRequestException($"There was an exception: { response.StatusCode }");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Room> DeleteAsync(long id)
        {
            try
            {
                HttpResponseMessage response = await this.HttpClient.DeleteAsync($"DeleteAsync/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Room>(responseContent);
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
