using System.Net.Sockets;
using System.Text;

namespace Assignment_10.Services
{
    public class PushNotificationClient
    {
        private const string ServerAddress = "127.0.0.1";
        private const int Port = 5000;

        public Task SendPushNotificationAsync(string recipient, string messageBody)
        {
            var message = $"{recipient}: {messageBody}";

            using (var client = new TcpClient(ServerAddress, Port))
            {
                using (var networkStream = client.GetStream())
                {
                    using (var writer = new System.IO.StreamWriter(networkStream, Encoding.UTF8))
                    {
                        writer.WriteLine(message);
                        writer.Flush();
                    }
                }                   
            }
                
            return Task.CompletedTask;
        }
    }
}
