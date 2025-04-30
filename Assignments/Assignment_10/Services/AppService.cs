using Assignment_11.Contracts;
using Assignment_11.Enums;

namespace Assignment_10.Services
{
    public class AppService(ILogger logger,
        NotificationService notificationService)
    {
        private const int MaxAttempts = 3;

        public async Task RunAsync()
        {
            while (true)
            {
                string? recipient = await PromptForValidRecipient();
                if (string.IsNullOrEmpty(recipient))
                {
                    await logger.LogAsync("RunAsync", "Too many invalid recipient attempts", LogType.Error);
                    Console.WriteLine("Too many invalid attempts. Please try again later.");
                    return;
                }

                string? message = await PromptForValidMessage();
                if (string.IsNullOrEmpty(message))
                {
                    await logger.LogAsync("RunAsync", "Too many invalid message attempts", LogType.Error);
                    Console.WriteLine("Too many invalid attempts. Please try again later.");
                    return;
                }

                try
                {
                    await notificationService.NotifyAsync(recipient, message);
                }
                catch (Exception ex)
                {
                    await logger.LogAsync("RunAsync", $"Failed to send notifications to {recipient}. Error: {ex.Message}", LogType.Error);
                    Console.WriteLine("Failed to send notifications. Please, try again later...");
                }

                Console.WriteLine("Do you want to send another message? (yes/no):");
                var response = Console.ReadLine();

                if (!string.Equals(response, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    await notificationService.NotifyPushOnlyAsync("", "exit");
                    break;
                }                   
            }
        }

        private async Task<string?> PromptForValidMessage()
        {
            var messageBody = "";

            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.WriteLine("Please enter the message you want to send:");
                messageBody = Console.ReadLine();

                if (!string.IsNullOrEmpty(messageBody))
                    return messageBody;

                await logger.LogAsync("PromptForValidMessage", $"Invalid email message input", LogType.Warning);
                Console.WriteLine($"Message cannot be empty. Attempt {attempt}/{MaxAttempts}.");
            }
            return null;
        }

        private async Task<string?> PromptForValidRecipient()
        {
            var recipient = "";
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.WriteLine("Please enter the recipient to send notifications to");
                recipient = Console.ReadLine();

                if (!string.IsNullOrEmpty(recipient))
                    return recipient;

                await logger.LogAsync("PromptForValidEmail", $"Empty recipient input", LogType.Warning);
                Console.WriteLine($"Recipient cannot be empty. Attempt {attempt}/{MaxAttempts}.");
            }
            return null;
        }
    }
}
