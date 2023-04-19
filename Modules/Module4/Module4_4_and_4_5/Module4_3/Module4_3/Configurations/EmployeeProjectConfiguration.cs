using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;

namespace Module4_3.Configurations;

public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        builder
            .ToTable("EmployeeProject")
            .HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasColumnName("EmployeeProjectId");
        builder.Property(e => e.Rate)
            .HasColumnType("money");

        builder.HasData(
            new EmployeeProject()
            {
                Id = 1,
                EmployeeId = 2,
                ProjectId = 2,
                Rate = 20,
                StartedDate = Convert.ToDateTime("01/07/2021")
            }, new EmployeeProject()
            {
                Id = 2,
                EmployeeId = 3,
                ProjectId = 4,
                Rate = 15,
                StartedDate = Convert.ToDateTime("01/08/2021")
            },
            new EmployeeProject()
            {
                Id = 3,
                EmployeeId = 1,
                ProjectId = 4,
                Rate = 18,
                StartedDate = Convert.ToDateTime("01/09/2021")
            },
            new EmployeeProject()
            {
                Id = 4,
                EmployeeId = 5,
                ProjectId = 1,
                Rate = 17,
                StartedDate = Convert.ToDateTime("01/10/2021")
            },
            new EmployeeProject()
            {
                Id = 5,
                EmployeeId = 3,
                ProjectId = 1,
                Rate = 15,
                StartedDate = Convert.ToDateTime("01/11/2021")
            }
        );
    }
}