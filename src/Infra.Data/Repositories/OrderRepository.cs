using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Data.Repositories
{
  public class OrderRepository
  {
    private readonly EFCoreDbContext context;

    public OrderRepository(EFCoreDbContext context)
    {
      this.context = context;
    }

    public bool Add(Order order)
    {

      context.Add(order);
      return context.SaveChanges() > 0;

    }

  }

}