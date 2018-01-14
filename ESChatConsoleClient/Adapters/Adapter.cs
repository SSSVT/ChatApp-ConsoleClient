using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public abstract class Adapter
    {
        protected readonly string _InvalidParams = "Invalid parameters";

        public virtual async Task Execute(string key, string input)
        {
            input = input.Replace($"{key} ", "");
        }
    }
}
