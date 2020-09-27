using CustomerService.Core.Common.Interfaces;
using CustomerService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Persistence
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Customers.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");
                var customers = new[]
                {
                    new Customer
                    {
                        Name = "Nasr",
                        CompanyName = "CompanyName 1",
                        Address = "Cairo Str. 37",
                        Region = "eastern region",
                        Country = "Egypt",
                        Mobile = "050000000"
                    },
                    new Customer
                    {
                        Name = "Mohamed",
                        CompanyName = "CompanyName 3",
                        Address = "Dubai Str. 37",
                        Region = "eastern",
                        Country = "UAE",
                        Mobile = "050000001"
                    },
                };

                await _context.Customers.AddRangeAsync(customers);
                _logger.LogInformation("Seeding Customers Done!");
                _logger.LogInformation("Seeding initial data completed");
            }

            await _context.SaveChangesAsync();
        }
    }
}
