using Assignment_10;
using Assignment_10.Services;
using Assignment_11;
using Microsoft.Extensions.Configuration;

class Program
{
    private const int MaxAttempts = 3;

    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpOptions>();

        if (smtpSettings == null)
        {
            Console.WriteLine("Missing required settings. Please, ensure everything is ok");
            return;
        }

        var logger = new FileLogger();
        var emailSender = new SmtpEmailSender(smtpSettings, logger);
        var appService = new EmailAppService(emailSender, logger);

        await appService.RunAsync();
    }  
}