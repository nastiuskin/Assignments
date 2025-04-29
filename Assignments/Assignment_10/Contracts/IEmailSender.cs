namespace Assignment_10_11.Contracts
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string recipientEmail, string messageBody);
    }
}
