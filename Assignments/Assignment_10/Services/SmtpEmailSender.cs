using System.Net;
using System.Net.Mail;

namespace Assignment_10.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private SmtpOptions _smtpOptions { get; set; }
        public SmtpEmailSender(SmtpOptions smtpOptions)
        {
            _smtpOptions = smtpOptions;
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

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}

