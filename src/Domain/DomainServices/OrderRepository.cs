using Domain.Entities;

namespace Domain.DomainServices
{
    public interface OrderRepository
    {
        void Add(Order order);

        ICollection<Order>? Get();

        Order? GetById(Guid id);

        bool SaveChanges();
    }
}