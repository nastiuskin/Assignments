using Assignment_10;
using Assignment_10.Services;
using Assignment_10_11.Contracts;
using Assignment_11;
using Assignment_11.Enums;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        var logger = new FileLogger();
        var emailValidator = new EmailValidator(logger);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpOptions>();

        if (smtpSettings == null)
        {
            await logger.LogAsync("Main", "Missing required settings.", LogType.Error);
            Console.WriteLine("Missing required settings. Please, ensure everything is ok");
            return;
        }

        var emailSender = new SmtpEmailSender(smtpSettings, logger);
        var pushNotificationClient = new PushNotificationClient();
        var emailClient = new EmailClient(emailSender, emailValidator, logger);

        var emailChannel = new EmailNotificationChannel(emailClient);
        var pushChannel = new PushNotificationChannel(pushNotificationClient);  

        var channels = new List<INotificationChannel> { emailChannel, pushChannel };

        var notificationService = new NotificationService(channels);

        var appService = new AppService(logger, notificationService);

        await appService.RunAsync();
    }
}