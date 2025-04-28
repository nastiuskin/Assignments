using Assignment_10;
using Assignment_10.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    private const int MaxAttempts = 3;

    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpOptions>();

        if (smtpSettings == null)
        {
            Console.WriteLine("Missing required settings. Please, ensure everything is ok");
            return;
        }

        var emailSender = new SmtpEmailSender(smtpSettings);

        var recipientEmail = PromptForValidEmail();

        if (string.IsNullOrEmpty(recipientEmail))
        {
            Console.WriteLine("Too many invalid attempts. Please, try again later.");
            return;
        }

        var messageBody = PromptForValidMessage();

        if (string.IsNullOrEmpty(messageBody))
        {
            Console.WriteLine("Too many invalid attempts. Please, try again later.");
            return;
        }

        await emailSender.SendEmailAsync(recipientEmail, messageBody);
    }

    private static string? PromptForValidEmail()
    {
        var emailAddress = "";
        for (int attempt = 1; attempt <= MaxAttempts; attempt++)
        {
            Console.WriteLine("Please enter the recipient's email address:");
            emailAddress = Console.ReadLine();

            if (EmailValidator.ValidateEmail(emailAddress).IsSuccess)
                break;

            Console.WriteLine($"Invalid email address. Attempt {attempt}/{MaxAttempts}.");
        }
        return emailAddress;
    }

    private static string? PromptForValidMessage()
    {
        var messageBody = "";

        for (int attempt = 1; attempt <= MaxAttempts; attempt++)
        {
            Console.WriteLine("Please enter the message you want to send:");
            messageBody = Console.ReadLine();

            if (EmailValidator.ValidateEmailBody(messageBody).IsSuccess)
                break;

            Console.WriteLine($"Invalid message body. Attempt {attempt}/{MaxAttempts}.");
        }
        return messageBody;
    }
}