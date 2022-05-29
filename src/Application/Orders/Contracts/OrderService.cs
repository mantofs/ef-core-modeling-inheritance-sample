using Domain.Entities;

namespace Application.Orders.Contracts
{
    public interface OrderService
    {
        bool CreateOrder(Guid customerId);
        IEnumerable<Order> GetOrders();
        void UpdateItem(Guid orderId);
        void RemoveItem(Guid orderId);
    }
}