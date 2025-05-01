using Assignment_10_11.Contracts;

namespace Assignment_10.Services
{
    public class PushNotificationChannel(PushNotificationClient notificationClient)
        : INotificationChannel
    {
        public async Task SendAsync(string recipient, string messageBody) => 
            await notificationClient.SendPushNotificationAsync(recipient, messageBody);
    }
}
