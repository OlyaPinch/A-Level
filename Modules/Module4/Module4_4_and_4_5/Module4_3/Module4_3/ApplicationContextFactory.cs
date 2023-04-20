using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_3
{
    public sealed class ConsoleApplicationContextFactory : IDesignTimeDbContextFactory<ConsoleApplicationContext>
    {
       public static string ConnectionString { get; set; }
        public ConsoleApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = ConnectionString;// "Data Source=DESKTOP-3D0016F\\MSSQLSERVER01;Initial Catalog=IT_Company_Module4_3; TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<ConsoleApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies()
                .Options;

            return new ConsoleApplicationContext(options);
        }

       
    }
}