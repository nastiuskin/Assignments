using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Assignment_12.PushConsoleApp
{
    public class ConsoleServer
    {
        private const int Port = 5000;

        public static void StartServer()
        {
            var listener = new TcpListener(IPAddress.Loopback, Port);
            listener.Start();
            Console.WriteLine($"Server started, waiting for notifications");

            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                {
                    var networkStream = client.GetStream();
                    using (var reader = new StreamReader(networkStream, Encoding.UTF8))
                    {
                        var message = reader.ReadLine();
                        if (message != null)
                            Console.WriteLine($"Received push notification to:  {message}");

                    }
                }
            }
        }
    }
}