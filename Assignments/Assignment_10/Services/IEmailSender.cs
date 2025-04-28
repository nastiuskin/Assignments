namespace Assignment_10.Services
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string recipientEmail, string messageBody);
    }
}
