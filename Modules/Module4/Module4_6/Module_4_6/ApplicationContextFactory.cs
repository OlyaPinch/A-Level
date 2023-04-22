using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Module_4_6.Configurations;
using Module_4_6.DbModels;

namespace Module_4_6
{
    internal class ApplicationContextFactory:  IDesignTimeDbContextFactory<ApplicationContext>
    {

        public static string ConnectionString { get; set; }





        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine,LogLevel.Information)
                .UseLazyLoadingProxies()
                .Options;

            return new ApplicationContext(options);
        }
    }
}
