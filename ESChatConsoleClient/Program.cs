using System;

namespace ESChatConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "ESChatConsoleClient for Windows";

                //Console.Write("Enter server URL: ");
                //string serverAddress = Console.ReadLine();
                //ClientEngine engine = new ClientEngine(serverAddress);

                ClientEngine engine = new ClientEngine("http://localhost:53513/api/v1/");
                //engine.StartAsync().Wait();
                engine.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.Message.ToString()}");
                Console.ReadLine();
            }
        }
    }
}
