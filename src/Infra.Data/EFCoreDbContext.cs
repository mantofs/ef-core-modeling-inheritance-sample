using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infra.Data;

public class EFCoreDbContext : DbContext
{
  public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
  {
  }

  public DbSet<Customer>? Customers { get; set; }
  public DbSet<Order>? Orders { get; set; }
  public DbSet<Item>? Items { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFCoreDbContext).Assembly);

  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
  {
    configuration.Properties<string>()
                 .AreFixedLength(false)
                 .AreUnicode(false)
                 .HaveMaxLength(300);

    configuration.Properties<decimal>()
                 .HavePrecision(8, 6);

  }
}