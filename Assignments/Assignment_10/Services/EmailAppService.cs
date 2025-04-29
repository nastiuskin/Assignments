using Assignment_11.Contracts;
using Assignment_11.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_10.Services
{
    public class EmailAppService
    {
        private readonly SmtpEmailSender _emailSender;
        private readonly ILogger _logger;
        private const int MaxAttempts = 3;
        public EmailAppService(SmtpEmailSender sender, ILogger logger)
        {
            _emailSender = sender;
            _logger = logger;
        }

        public async Task RunAsync()
        {
            string? recipient = await PromptForValidEmail();
            if (string.IsNullOrEmpty(recipient))
            {
                await _logger.LogAsync("PromptForValidEmail", "Too many invalid email attempts", LogType.Error);
                Console.WriteLine("Too many invalid attempts. Please, try again later...");
                return;
            }

            string? message = await PromptForValidMessage();
            if (string.IsNullOrEmpty(message))
            {
                await _logger.LogAsync("PromptForValidMessage", "Too many invalid attempts", LogType.Error);
                Console.WriteLine("Too many invalid attempts. Please, try again later...");
                return;
            }

            try
            {
                await _emailSender.SendEmailAsync(recipient, message);
            }
            catch (Exception ex)
            {
                await _logger.LogAsync("SendEmailAsync", $"Failed to send email to {recipient}. Error: {ex.Message}", LogType.Error);
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

                if (EmailValidator.ValidateEmail(emailAddress).IsSuccess)
                    break;

                await _logger.LogAsync("PromptForValidEmail", $"Invalid email input: {emailAddress}", LogType.Warning);
                Console.WriteLine($"Invalid email address. Attempt {attempt}/{MaxAttempts}.");
            }
            return emailAddress;
        }

        private async Task<string?> PromptForValidMessage()
        {
            var messageBody = "";

            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.WriteLine("Please enter the message you want to send:");
                messageBody = Console.ReadLine();

                if (EmailValidator.ValidateEmailBody(messageBody).IsSuccess)
                    break;

                await _logger.LogAsync("PromptForValidMessage", $"Invalid email message input", LogType.Warning);
                Console.WriteLine($"Invalid message body. Attempt {attempt}/{MaxAttempts}.");
            }
            return messageBody;
        }
    }
}
