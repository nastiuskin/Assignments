using Assignment_10;
using Assignment_10.Services;
using Assignment_11;
using Assignment_11.Enums;
using Microsoft.Extensions.Configuration;

class Program
{
    private const int MaxAttempts = 3;

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
        var appService = new EmailAppService(emailSender,emailValidator, logger);

        await appService.RunAsync();
    }  
}