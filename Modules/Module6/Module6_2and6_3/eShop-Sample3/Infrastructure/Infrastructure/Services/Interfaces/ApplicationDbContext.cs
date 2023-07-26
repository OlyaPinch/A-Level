using Catalog.Host.Data.EntityConfigurations;
using Infrastructure.Data.Entities;
using Infrastructure.Data.EntityConfigurations;
using Infrastructure.Models.Basket;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Interfaces;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<BasketData> BasketData { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
    }


}