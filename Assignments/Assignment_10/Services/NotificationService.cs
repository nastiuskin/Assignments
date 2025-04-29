using Assignment_10_11.Contracts;

namespace Assignment_10.Services
{
    public class NotificationService(IEnumerable<INotificationChannel> channels)
    {
        public async Task NotifyAsync(string recipient, string message)
        {
            foreach (var channel in channels)
            {
                await channel.SendAsync(recipient, message);
            }
        }
    }
}
