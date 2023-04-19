using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;

namespace Module4_3.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .ToTable("Project")
            .HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .HasColumnName("ProjectId")
            .ValueGeneratedNever();
        builder.Property(p => p.Name)
            .HasMaxLength(50);
        builder.Property(p => p.Budget)
            .HasColumnType("money");

        builder.HasData(
                new Project()
                {
                    Id = 1,
                    Name = "One game",
                    StartedDate = Convert.ToDateTime("12-01-2000"),
                    Budget = 20000,
                    ClientId = 5
                },
                new Project()
                {
                    Id = 2,
                    Name = "Second game",
                    StartedDate = Convert.ToDateTime("01-01-2005"),
                    Budget = 30000,
                    ClientId = 4
                },
                new Project()
                {
                    Id = 3,
                    Name = "Business1",
                    StartedDate = Convert.ToDateTime("01-01-2020"),
                    Budget = 100000,
                    ClientId = 3
                },
                new Project()
                {
                    Id = 4,
                    Name = "Business2",
                    StartedDate = Convert.ToDateTime("01-01-2021"),
                    Budget = 150000,
                    ClientId = 2
                },
                new Project()
                {
                    Id = 5,
                    Name = "Business3",
                    StartedDate = Convert.ToDateTime("02-02-2020"),
                    Budget = 1000,
                    ClientId = 1
                }
            )
            ;
    }
}