using Assignment_10_11.Contracts;

namespace Assignment_10.Services
{
    public class NotificationService(IEnumerable<INotificationChannel> channels)
    {
        public async Task NotifyAsync(string recipient, string message)
        {
            await Task.WhenAll(channels.Select(c => c.SendAsync(recipient, message)));
        }

        public async Task NotifyPushOnlyAsync(string recipient, string message)
        {
            var tasks = channels
             .Where(c => c is PushNotificationChannel)
             .Select(c => c.SendAsync(recipient, message));

            await Task.WhenAll(tasks);
        }
    }
}

