using Assignment_15.Enums;

namespace Assignment_15.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public Guid BookId { get; set; }
        public Guid CustomerId { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }

        public Order(Guid bookId, Guid customerId) 
        {
            Id = Guid.NewGuid();
            BookId = bookId;
            CustomerId = customerId;
            Status = OrderStatus.Created;
        }            

        public void UpdateStatus(OrderStatus status) => Status = status;

        public override string ToString()
        {
            return $"Order #{Id} | Book: {BookId} | Status: {Status}";
        }
    }
}
