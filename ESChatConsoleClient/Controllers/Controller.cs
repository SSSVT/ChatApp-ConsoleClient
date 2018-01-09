using System.Net.Http;

namespace ESChatConsoleClient.Controllers
{
    public abstract class Controller
    {
        public Controller(string serverUrl, string controllerName)
        {
            this._URL = serverUrl;
            this._Controller = controllerName;
            this.HttpClient = new HttpClient()
            {
                BaseAddress = new System.Uri(serverUrl + controllerName + "/")
            };
        }

        #region Fields
        public readonly string _Controller;
        public readonly string _URL;
        #endregion

        #region Properties
        public HttpClient HttpClient { get; }
        #endregion
    }
}
