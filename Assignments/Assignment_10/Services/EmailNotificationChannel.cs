using Assignment_10_11.Contracts;

namespace Assignment_10.Services
{
    public class EmailNotificationChannel(EmailClient emailClient) :
        INotificationChannel
    {
        public async Task SendAsync(string recipient, string messageBody) =>
            await emailClient.SendEmailAsync(recipient, messageBody);
    }
}
