using Assignment_11.Enums;
using System.Net;
using System.Net.Mail;
using ILogger = Assignment_11.Contracts.ILogger;

namespace Assignment_10.Services
{
    public class SmtpEmailSender(SmtpOptions smtpOptions,ILogger logger)
    {
        public async Task SendEmailAsync(string recipientEmail, string messageBody)
        {
            try
            {
                using (var client = new SmtpClient(smtpOptions.Host, smtpOptions.Port))
                {
                    client.EnableSsl = smtpOptions.EnableSsl;
                    client.Credentials = new NetworkCredential(smtpOptions.Username, smtpOptions.Password);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(smtpOptions.Username, "Newsletter Team");
                        message.To.Add(recipientEmail);
                        message.Subject = "Message from Newsletter Team";
                        message.Body = messageBody;
                        message.IsBodyHtml = false;

                        await client.SendMailAsync(message);
                    }
                }

                await logger.LogAsync("SendEmailAsync", $"Email sent successfuly to {recipientEmail}. Message: {messageBody}", LogType.Info);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                await logger.LogAsync("SendEmailAsync", $"Failed to send email to {recipientEmail}. Error: {ex.Message}", LogType.Error);
                Console.WriteLine($"Error sending email. Please, try again later...");
            }
        }     
    }
}

