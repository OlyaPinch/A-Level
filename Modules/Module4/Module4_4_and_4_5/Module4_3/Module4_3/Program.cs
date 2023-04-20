using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Module4_3.DbModels;

namespace Module4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            var connString = configuration.GetConnectionString("SQLConn");
            ConsoleApplicationContextFactory.ConnectionString = connString;


            using (var context =
                   new ConsoleApplicationContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                // context.Database.EnsureCreated();
                var employees = context.Employees.ToList();

                var employees1 = context.Employees
                    .Include(i => i.Office).Where(office => office.Office.Location == "Kyiv")
                    .Include(i => i.Title)
                    .Where(i => i.TitleId == 1)
                    .ToList();

                var difDays = context.Employees.Select((i => new
                    { id = i.Id, days = EF.Functions.DateDiffDay(i.DateOfBirth, DateTime.UtcNow) })).ToList();

                var transaction = context.Database.BeginTransaction();
                try
                {
                    var office1 = context.Offices.Find(1);
                    var office2 = context.Offices.Find(2);

                    office1.Title += "changed";
                    office1.Title += "changed";
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

                var Emploee6 = new Employee()
                {
                    Id = 7,
                    FirstName = "NewEmployee2 ",
                    LastName = "NewLastName",
                    HiredDate = DateTime.Parse("01-01-2022"),
                    DateOfBirth = DateTime.Parse("19-04-2005"),
                    OfficeId = 3,
                    TitleId = 1,
                };

                context.Employees.Add(Emploee6);
                var project6 = new Project()
                {
                    Id = 8,
                    Name = "Business7",
                    StartedDate = Convert.ToDateTime("02-02-2022"),
                    Budget = 10000,
                    ClientId = 2
                };
                context.Projects.Add(project6);
                var title1 = new Title()
                {
                    Id = 7,
                    Name = "Accountant"
                };
                context.Titles.Add(title1);
                context.SaveChanges();
                var empl = context.Employees.Find(6);
                context.Employees.Remove(empl);
                context.SaveChanges();
                var empGroup = context.Employees
                    .Where(i => !EF.Functions.Like(i.Title.Name, "%a%"))
                    .GroupBy(i => i.Title.Name)
                    .ToList();
                //Console.WriteLine(emloee1.ToQueryString());
            }


            //Console.ReadKey();
        }
    }
}