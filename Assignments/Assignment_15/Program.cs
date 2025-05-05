using Assignment_15.Abstractions;
using Assignment_15.Entities;
using Assignment_15.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var book = new Book("The Great Gatsby", "F. Scott Fitzgerald", 250);
        var book2 = new Book("It", "Stephen King ", 250);

        var emailChannel = new EmailNotificationChannel();
        var smsChannel = new SmsNotificationChannel();

        var customer = new Customer("Customer1", new List<INotificationChannel> { emailChannel, smsChannel });

        var staff1 = new StaffMember("StaffMember1", smsChannel);
        var staff2 = new StaffMember("StaffMember2", smsChannel);

        var orderProcessor = new OrderProcessor();

        orderProcessor.Subscribe(customer); 
        orderProcessor.Subscribe(staff1);
        orderProcessor.Subscribe(staff2);

        var order = orderProcessor.PlaceOrder(book.Id, customer.Id);

        orderProcessor.StartProcessing(order.Id);           
        orderProcessor.MarkOrderReadyToShip(order.Id);     
        orderProcessor.ShipOrder(order.Id);                
        orderProcessor.DeliverOrder(order.Id);              

        orderProcessor.Unsubcribe(staff2);
        customer.RemoveChannel(emailChannel);

        Console.WriteLine("Staff2 unsubscribed, ihuuuuuu\n");

        var order2 = orderProcessor.PlaceOrder(book2.Id, customer.Id);

        orderProcessor.StartProcessing(order.Id);
        orderProcessor.MarkOrderReadyToShip(order.Id);
        orderProcessor.ShipOrder(order.Id);
        orderProcessor.DeliverOrder(order.Id);

    }
}
