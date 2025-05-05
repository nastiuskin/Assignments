using Assignment_15.Abstractions;

namespace Assignment_15.Entities
{
    public class Customer : IObserver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<INotificationChannel> Channels { get; set; } = [];
        public Customer(string name, List<INotificationChannel> channels)
        {
            Id = Guid.NewGuid();
            Name = name;
            Channels = channels;
        }

        public void Update(string message) => Channels.ForEach(x => x.Send(Name,message));

        public void AddChannel(INotificationChannel channel) => Channels.Add(channel);
        public void RemoveChannel(INotificationChannel notificationChannel) => Channels.Remove(notificationChannel);
    }
}
