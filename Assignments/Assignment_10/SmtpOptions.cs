namespace Assignment_10
{
    public class SmtpOptions
    {
        public required string Host { get; set; }
        public required int Port { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required bool EnableSsl { get; set; }
    }
}
