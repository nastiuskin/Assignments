using Assignment_15.Abstractions;
using Assignment_15.Entities;
using Assignment_15.Enums;

namespace Assignment_15.Services
{
    public class OrderProcessor : ISubject
    {
        private readonly List<IObserver> _observers = new();
        private readonly List<Order> _orders = new();

        public void Subscribe(IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Unsubcribe(IObserver observer) => _observers.Remove(observer);

        public void Notify(OrderStatus orderStatus, string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public Order PlaceOrder(Guid bookId, Guid customerId)
        {
            var order = new Order(bookId, customerId);
            _orders.Add(order);

            NotifyStaffMember($"New order placed: {order}");

            return order;
        }

        public void StartProcessing(Guid orderId)
        {
            var order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) return;

            order.UpdateStatus(OrderStatus.Processing);
            NotifyCustomer(order.CustomerId, $"Your order {order.Id} is now being processed.");
        }

        public void CancelOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return;

            order.UpdateStatus(OrderStatus.Cancelled);
            NotifyCustomer(order.CustomerId, $"Your order {order.Id} was cancelled.");
        }

        public void MarkOrderReadyToShip(Guid orderId)
        {
            var order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) return;

            order.UpdateStatus(OrderStatus.ReadyToShip);
            NotifyStaffMember($"Order {order.Id} is ready to ship.");
        }

        public void ShipOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) return;

            order.UpdateStatus(OrderStatus.Shipped);
            NotifyCustomer(order.CustomerId, $"Your order {order.Id} has been shipped.");
        }

        public void DeliverOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) return;

            order.UpdateStatus(OrderStatus.Delivered);
            NotifyCustomer(order.CustomerId, $"Your order {order.Id} has been delivered.");
        }

        private void NotifyCustomer(Guid customerId, string message)
        {
            var customer = _observers
               .OfType<Customer>()
               .FirstOrDefault(c => c.Id == customerId);

            customer?.Update(message);
        }

        private void NotifyStaffMember(string message)
        {
            foreach (var staff in _observers.Where(x => x is StaffMember))
            {
                if (_observers.Contains(staff))
                    staff.Update(message);
            }
        }

        private bool IsCustomerNotifiableStatus(OrderStatus status) =>
            status is OrderStatus.Processing
            or OrderStatus.Shipped
            or OrderStatus.Cancelled;
    }
}
