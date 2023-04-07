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



    }
}