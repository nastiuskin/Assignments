namespace Assignment_10_11.Contracts
{
    public interface INotificationChannel
    {
        public Task SendAsync(string recipient, string messageBody);
    }
}
