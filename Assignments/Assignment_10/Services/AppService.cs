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
                string? recipient = await GetValidInput("recipient", PromptForValidRecipient);
                if (recipient is null) return;

                string? message = await GetValidInput("message", PromptForValidMessage);
                if (message is null) return;

                await TrySendNotificationsAsync(recipient, message);

                if (!AskToContinue())
                {
                    await notificationService.NotifyPushOnlyAsync("", "exit");
                    break;
                }
            }
        }
        private bool AskToContinue()
        {
            Console.WriteLine("Do you want to send another message? (yes/no):");
            var response = Console.ReadLine();
            return string.Equals(response, "yes", StringComparison.OrdinalIgnoreCase);
        }

        private async Task TrySendNotificationsAsync(string recipient, string message)
        {
            try
            {
                await notificationService.NotifyAsync(recipient, message);
            }
            catch (Exception ex)
            {
                await logger.LogAsync("RunAsync", $"Failed to send notifications to {recipient}. Error: {ex.Message}", LogType.Error);
                Console.WriteLine("Failed to send notifications. Please, try again later...");
            }
        }

        private async Task<string?> GetValidInput(string type, Func<Task<string?>> prompt)
        {
            string? result = await prompt();
            if (string.IsNullOrEmpty(result))
            {
                await logger.LogAsync("RunAsync", $"Too many invalid {type} attempts", LogType.Error);
                Console.WriteLine($"Too many invalid attempts. Please try again later.");
            }
            return result;
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
