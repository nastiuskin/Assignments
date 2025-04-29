using Assignment_11.Contracts;
using Assignment_11.Enums;

namespace Assignment_10.Services
{
    public class EmailAppService(SmtpEmailSender emailSender,
        EmailValidator emailValidator,
        ILogger logger)
    {
        private const int MaxAttempts = 3;
        public async Task RunAsync()
        {
            string? recipient = await PromptForValidEmail();
            if (string.IsNullOrEmpty(recipient))
            {
                await logger.LogAsync("RunAsync", "Too many invalid email attempts", LogType.Error);
                Console.WriteLine("Too many invalid attempts. Please, try again later...");
                return;
            }

            string? message = await PromptForValidMessage();
            if (string.IsNullOrEmpty(message))
            {
                await logger.LogAsync("RunAsync", "Too many invalid attempts", LogType.Error);
                Console.WriteLine("Too many invalid attempts. Please, try again later...");
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

        private async Task<string?> PromptForValidEmail()
        {
            var emailAddress = "";
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.WriteLine("Please enter the recipient's email address:");
                emailAddress = Console.ReadLine();

                if (emailValidator.ValidateEmail(emailAddress).Result.IsSuccess)
                    return emailAddress;

                await logger.LogAsync("PromptForValidEmail", $"Invalid email input: {emailAddress}", LogType.Warning);
                Console.WriteLine($"Invalid email address. Attempt {attempt}/{MaxAttempts}.");
            }
            return null;
        }

        private async Task<string?> PromptForValidMessage()
        {
            var messageBody = "";

            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.WriteLine("Please enter the message you want to send:");
                messageBody = Console.ReadLine();

                if (emailValidator.ValidateEmailBody(messageBody).Result.IsSuccess)
                    return messageBody;

                await logger.LogAsync("PromptForValidMessage", $"Invalid email message input", LogType.Warning);
                Console.WriteLine($"Invalid message body. Attempt {attempt}/{MaxAttempts}.");
            }
            return null;
        }
    }
}
