using System.Net.Sockets;
using System.Text;

namespace Assignment_10.Services
{
    public class PushNotificationClient
    {
        private const string ServerAddress = "127.0.0.1";
        private const int Port = 5000;

        public async Task SendPushNotificationAsync(string recipient, string messageBody)
        {
            using (var client = new TcpClient(ServerAddress, Port))
            {
                using (var networkStream = client.GetStream())
                {
                    using (var writer = new StreamWriter(networkStream))                    
                        await writer.WriteLineAsync(messageBody);                   
                }
            }
        }
    }
}
