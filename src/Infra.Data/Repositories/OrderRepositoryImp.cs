using Domain.DomainServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class OrderRepositoryImp : OrderRepository
    {
        private readonly EFCoreDbContext context;

        public OrderRepositoryImp(EFCoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders?.Add(order);
        }

        public ICollection<Order>? Get() => context.Orders?.ToList();

        public Order GetById(Guid id)
        {
            return context.Orders?.Include(model => model.Items)
                                  .FirstOrDefault(model => model.Id == id);
        }

        public bool SaveChanges()
        {

            return context.SaveChanges(true) > 0;

        }


    }
}