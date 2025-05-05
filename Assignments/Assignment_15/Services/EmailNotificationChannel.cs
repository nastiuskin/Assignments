using Assignment_15.Abstractions;

namespace Assignment_15.Services
{
    public class EmailNotificationChannel : INotificationChannel
    {
        public void Send(string recipientName, string message)
        {
            Console.WriteLine($"[Email] to {recipientName}: {message}");
        }
    }
}
