using Assignment_10_11.Contracts;
using Assignment_11.Contracts;
using Assignment_11.Enums;
using System.Net;
using System.Net.Mail;

namespace Assignment_10.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private SmtpOptions _smtpOptions { get; set; }
        private ILogger _logger { get; set; }
        public SmtpEmailSender(SmtpOptions smtpOptions, ILogger logger)
        {
            _smtpOptions = smtpOptions;
            _logger = logger;
        }

        public async Task SendEmailAsync(string recipientEmail, string messageBody)
        {
            try
            {
                using (var client = new SmtpClient(_smtpOptions.Host, _smtpOptions.Port))
                {
                    client.EnableSsl = _smtpOptions.EnableSsl;
                    client.Credentials = new NetworkCredential(_smtpOptions.Username, _smtpOptions.Password);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(_smtpOptions.Username, "Newsletter Team");
                        message.To.Add(recipientEmail);
                        message.Subject = "Message from Newsletter Team";
                        message.Body = messageBody;
                        message.IsBodyHtml = false;

                        await client.SendMailAsync(message);
                    }
                }

                await _logger.LogAsync("SendEmailAsync", $"Email sent successfuly to {recipientEmail}. Message: {messageBody}", LogType.Info);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                await _logger.LogAsync("SendEmailAsync", $"Failed to send email to {recipientEmail}. Error: {ex.Message}", LogType.Error);
                Console.WriteLine($"Error sending email. Please, try again later...");
            }
        }
    }
}

