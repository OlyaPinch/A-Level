using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfigurations;

public class OrderItemEntityTypeConfiguration:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("Orders");
        
        builder.Property(ci => ci.Id)
            .UseHiLo("order_hilo")
            .IsRequired();
        builder.HasOne(ci => ci.CatalogItem)
            .WithOne()
            .HasForeignKey<CatalogItem>(ci => ci.Id);
    }
}