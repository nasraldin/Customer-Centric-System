using AccountService.Core.Common.Interfaces;
using AccountService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AccountService.Infrastructure.Persistence
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

            if (!await _context.Accounts.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");
                var accounts = new[]
                {
                    new Account
                    {
                        Number = 213213,
                        Type = "Acc Type",
                        Balance = 29.5f,
                        CustomerId = 1
                    },
                    new Account
                    {
                        Number = 898989,
                        Type = "Acc Type 2",
                        Balance = 30,
                        CustomerId = 2
                    },
                };

                await _context.Accounts.AddRangeAsync(accounts);
                _logger.LogInformation("Seeding Accounts Done!");
                _logger.LogInformation("Seeding initial data completed");
            }

            await _context.SaveChangesAsync();
        }
    }
}
