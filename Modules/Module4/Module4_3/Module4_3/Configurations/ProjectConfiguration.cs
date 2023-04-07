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
    }
}