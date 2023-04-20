using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;

namespace Module4_3.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employee")
            .HasKey(e => e.Id);
        builder
            .Property(e => e.Id)
            .HasColumnName("EmployeeId")
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
                FirstName = "Olha",
                LastName = "Pinchuk",
                HiredDate = default,
                DateOfBirth = DateTime.Parse("08-12-1985"),
                OfficeId = 1,
                TitleId = 1,
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Maria",
                LastName = "Glamazda",
                HiredDate = default,
                DateOfBirth = DateTime.Parse("25-04-2000"),
                OfficeId = 1,
                TitleId = 1,
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Anatolii",
                LastName = "Anatolii",
                HiredDate = default,
                DateOfBirth = DateTime.Parse("07-10-1984"),
                OfficeId = 1,
                TitleId = 1,
            },
            new Employee()
            {
                Id = 4,
                FirstName = "Olha",
                LastName = "Ilchuk",
                HiredDate = default,
                DateOfBirth = DateTime.Parse("20-02-1995"),
                OfficeId = 1,
                TitleId = 1,
            },
            new Employee()
            {
                Id = 5,
                FirstName = "Kateryna",
                LastName = "Pinchuk",
                HiredDate = default,
                DateOfBirth = DateTime.Parse("19-07-2012"),
                OfficeId = 1,
                TitleId = 1,

            }
        );
    }
}