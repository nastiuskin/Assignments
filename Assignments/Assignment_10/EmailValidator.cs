using Assignment_11.Contracts;
using Assignment_11.Enums;
using FluentResults;
using System.Net.Mail;

namespace Assignment_10
{
    public class EmailValidator(ILogger logger)
    {
        public async Task<Result> ValidateEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                await logger.LogAsync("ValidateEmail", "Email is empty", LogType.Error);
                return Result.Fail("Email cannot be empty.");
            }               

            try
            {
                var addr = new MailAddress(email);
                if (addr.Address == email)
                {
                    await logger.LogAsync("ValidateEmail", "Email is valid", LogType.Info);
                    return Result.Ok();
                }
                else
                {
                    await logger.LogAsync("ValidateEmail", "Ivalid email format", LogType.Error);
                    return Result.Fail("Invalid email format.");
                }
            }
            catch (Exception ex)
            {
                await logger.LogAsync("ValidateEmail", ex.Message, LogType.Error);
                return Result.Fail($"Unexpected error occured: {ex.Message}");
            }
        }

        public async Task<Result> ValidateEmailBody(string? emailBody)
        {
            if (!string.IsNullOrEmpty(emailBody))
            {
                await logger.LogAsync("ValidateEmailBody", "Message body is valid", LogType.Info);
                return Result.Ok();
            }
            else
            {
                await logger.LogAsync("ValidateEmailBody", "Message body is empty", LogType.Error);
                return Result.Fail("Message body cannot be empty.");
            }
        }
    }
}