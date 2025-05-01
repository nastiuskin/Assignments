using Assignment_11.Enums;
using ILogger = Assignment_11.Contracts.ILogger;

namespace Assignment_10.Services
{
    public class EmailClient(
        SmtpEmailSender emailSender, 
        EmailValidator emailValidator, 
        ILogger logger)
    {
        public async Task SendEmailAsync(string recipient, string message)
        {
            var recipientValidation = await emailValidator.ValidateEmail(recipient);
            if (recipientValidation.IsFailed)
            {
                await logger.LogAsync("SendEmailAsync", $"Invalid recipient email: {recipient}", LogType.Error);
                Console.WriteLine("Invalid recipient email. Email not sent.");
                return;
            }

            var messageValidation = await emailValidator.ValidateEmailBody(message);
            if (messageValidation.IsFailed)
            {
                await logger.LogAsync("SendEmailAsync", $"Invalid message body", LogType.Error);
                Console.WriteLine("Invalid message body. Email not sent.");
                return;
            }

            try
            {
                await emailSender.SendEmailAsync(recipient, message);
            }
            catch (Exception ex)
            {
                await logger.LogAsync("RunAsync", $"Failed to send email to {recipient}. Error: {ex.Message}", LogType.Error);
                Console.WriteLine("Failed to send email. Please, try again later...");
            }
        }
    }
}
