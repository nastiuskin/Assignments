using System.Net;
using System.Net.Sockets;

namespace Assignment_12.PushConsoleApp
{
    public class ConsoleServer
    {
        private const int Port = 5000;

        public static void StartServer()
        {
            using (var listener = new TcpListener(IPAddress.Loopback, Port))
            {
                listener.Start();
                Console.WriteLine($"Server started, waiting for notifications");

                while (true)
                {
                    using (var client = listener.AcceptTcpClient())
                    {
                        var networkStream = client.GetStream();
                        using (var reader = new StreamReader(networkStream))
                        {
                            var message = reader.ReadLine();
                            if (message != null)
                            {
                                if (message == "exit")
                                {
                                    Console.WriteLine("Received shutdown signal.");
                                    break;
                                }

                                Console.WriteLine($"Received push notification: {message}");
                            }
                        }
                    }
                }
            }
        }


    }
}
