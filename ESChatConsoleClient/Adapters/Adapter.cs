using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public abstract class Adapter
    {
        protected readonly string _InvalidParams = "Invalid parameters";

        public abstract Task Execute(string key, string input);
    }
}
