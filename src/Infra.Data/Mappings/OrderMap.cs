using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings;
public class OrderMap : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.HasKey(order => order.Id);
        builder.Property(order => order.Id)
               .ValueGeneratedNever();

    builder.Property(order => order.CustomerId)
           .IsRequired();

    builder.HasOne(order => order.Customer)
           .WithMany(item => item.Orders)
           .HasForeignKey(order=>order.CustomerId);


    }

}
public class PurchaseOrderMap : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.HasBaseType<Order>();
    }
}
public class WithdrawOrderMap : IEntityTypeConfiguration<WithdrawOrder>
{
    public void Configure(EntityTypeBuilder<WithdrawOrder> builder)
    {
        builder.HasBaseType<Order>();
    }

}
