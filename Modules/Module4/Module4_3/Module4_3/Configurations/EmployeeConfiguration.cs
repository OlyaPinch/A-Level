using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;

namespace Module4_3.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Emloyee")
            .HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasColumnName("EmploeeId")
            .ValueGeneratedNever();

        builder
            .Property(e => e.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50);
        builder
            .Property(e => e.LastName)
            .HasMaxLength(50);

        builder.HasData(new Employee
            {
                Id = 1,
                FirstName = "Olga",
                LastName = "Pinchuk",
                HiredDate = default,
                DateOfBirth = DateTime.Parse("08-12-00"),
                OfficeId = 1,
                TitleId = 1,
            }
        );
    }
}