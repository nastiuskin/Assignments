using Assignment_10_11.Contracts;
using System.Threading.Channels;

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

        public async Task NotifyPushOnlyAsync(string recipient, string message)
        {
            foreach (var channel in channels)
            {
                if (channel is PushNotificationChannel)
                {
                    await channel.SendAsync(recipient, message);
                }
            }
        }
    }
}

