using Microsoft.EntityFrameworkCore;
using Module4_3.Configurations;
using Module4_3.DbModels;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Module4_3;

public class ConsoleApplicationContext: DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Office> Offices { get; set; }

    public DbSet<Project> Projects { get; set; }

    

    public DbSet<Title>Titles{ get; set; }

    public DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public ConsoleApplicationContext(DbContextOptions<ConsoleApplicationContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new OfficeConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TitleConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
    }
}