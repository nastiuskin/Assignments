namespace Assignment_15.Abstractions
{
    public interface INotificationChannel
    {
        void Send(string recipientName, string message);
    }
}
    