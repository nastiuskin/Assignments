using Assignment_15.Abstractions;

namespace Assignment_15.Entities
{
    public class StaffMember : IObserver
    {
        public string Name { get; }
        public INotificationChannel Channel { get; }

        public StaffMember(string name, INotificationChannel channel)
        {
            Name = name;
            Channel = channel;
        }

        public void Update(string message) => Channel.Send(Name, message);
    }
}
