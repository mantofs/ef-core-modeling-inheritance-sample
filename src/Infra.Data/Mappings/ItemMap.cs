using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings;

public class ItemMap : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id)
               .ValueGeneratedNever();

        builder.HasOne(item => item.Order)
               .WithMany(order => order.Items)
               .IsRequired();
    }
}