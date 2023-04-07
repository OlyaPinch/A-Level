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
                Location = "Ukraine",

            });
    }
}