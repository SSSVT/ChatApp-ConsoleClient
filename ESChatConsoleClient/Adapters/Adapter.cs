using ESChatConsoleClient.Data;
using System.Threading.Tasks;

namespace ESChatConsoleClient.Adapters
{
    public abstract class Adapter
    {
        public Adapter()
        {
            this.DataContext = DataContext.GetInstance();
        }

        protected DataContext DataContext { get; set; }

        protected readonly string _InvalidParams = "Invalid parameters";
        protected readonly string _Successful = "Successful";

        public abstract Task Execute(string key, string input);

        public virtual string RemoveCommand(string key, string input) => input.Replace($"{key} ", "");
    }
}
