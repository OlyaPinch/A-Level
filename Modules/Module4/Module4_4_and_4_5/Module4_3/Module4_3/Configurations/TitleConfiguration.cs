using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;

namespace Module4_3.Configurations;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder
            .ToTable("Title")
            .HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedNever();
        builder.Property(t => t.Name)
            .HasMaxLength(50);
        builder
            .HasData(new Title
            {
                Id = 1,
                Name = "Developer"
            },
                new Title
                {
                    Id = 2,
                    Name = "QA Engineer"
                },
                new Title
                {
                    Id = 3,
                    Name = "Manager"
                },
                new Title
                {
                    Id = 4,
                    Name = "Scrum master"
                },
                new Title
                {
                    Id = 5,
                    Name = "Asistent"
                });
    }
}