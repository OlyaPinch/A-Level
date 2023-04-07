using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

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
            using (var context =
                   new ConsoleApplicationContextFactory(connString).CreateDbContext(Array.Empty<string>()))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}