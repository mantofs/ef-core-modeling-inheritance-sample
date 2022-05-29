using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DomainServices
{
    public interface CustomerRepository
    {
        void Add(Customer customer);
        bool Commit();
        ICollection<Customer>? Get();
    }
}