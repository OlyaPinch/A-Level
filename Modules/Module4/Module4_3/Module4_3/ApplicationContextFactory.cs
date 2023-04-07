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
        private readonly string _connectionString;

        public ConsoleApplicationContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ConsoleApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsoleApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(_connectionString)
                .Options;

            return new ConsoleApplicationContext(options);
        }
    }
}