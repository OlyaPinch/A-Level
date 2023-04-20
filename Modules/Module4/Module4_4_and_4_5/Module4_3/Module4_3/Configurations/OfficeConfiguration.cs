using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;

namespace Module4_3.Configurations;

public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder
            .ToTable("Office")
            .HasKey(o => o.Id);
        builder
            .Property(o => o.Id)
            .HasColumnName("OfficeId")
            .ValueGeneratedNever();
        builder
            .Property(o => o.Title)
            .HasMaxLength(100);
        builder
            .Property(o => o.Location)
            .HasMaxLength(100);
        builder
            .HasData(new Office
                {
                    Id = 1,
                    Title = "New office",
                    Location = "Kyiv",
                },
                new Office
                {
                    Id = 2,
                    Title = "Old office",
                    Location = "Lviv",
                }, new Office
                {
                    Id = 3,
                    Title = "Poland office",
                    Location = "Varshava",
                }, new Office
                {
                    Id = 4,
                    Title = "British office",
                    Location = "London",
                }, new Office
                {
                    Id = 5,
                    Title = "USA office",
                    Location = "New-York",
                });
    }
}