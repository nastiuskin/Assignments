using FluentResults;
using System.Net.Mail;

namespace Assignment_10
{
    public class EmailValidator
    {
        public static Result ValidateEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Fail("Email cannot be empty.");

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email
                    ? Result.Ok()
                    : Result.Fail("Invalid email format.");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Unexpected error occured: {ex.Message}");
            }
        }

        public static Result ValidateEmailBody(string? emailBody)
        {
            return !string.IsNullOrEmpty(emailBody)
                ? Result.Ok()
                : Result.Fail("Message body cannot be empty.");
        }
    }
}