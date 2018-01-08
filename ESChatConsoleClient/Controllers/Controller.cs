using System.Net.Http;

namespace ESChatConsoleClient.Controllers
{
    public abstract class Controller
    {
        public Controller(string serverUrl)
        {
            this._URL = serverUrl;
            this.HttpClient = new HttpClient()
            {
                BaseAddress = new System.Uri(serverUrl)
            };
        }

        #region Fields
        public readonly string _URL;
        #endregion

        #region Properties
        public HttpClient HttpClient { get; }
        #endregion
    }
}
