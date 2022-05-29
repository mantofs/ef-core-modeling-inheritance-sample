using Domain.DomainServices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CustomerRepositoryImp : CustomerRepository
    {
        private readonly EFCoreDbContext context;

        public CustomerRepositoryImp(EFCoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer) => context.Customers?.Add(customer);

        public ICollection<Customer>? Get() => context.Customers?.ToList();

        public bool Commit() => context.SaveChanges(true) > 0;

    }
}