using Assignment_15.Abstractions;

namespace Assignment_15.Services
{
    public class SmsNotificationChannel : INotificationChannel
    {
        public void Send(string recipientName, string message)
        {
            Console.WriteLine($"[SMS] to {recipientName}: {message}");
        }
    }
}
