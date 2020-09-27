using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StatementService.Core.Common.Interfaces;
using StatementService.Core.Entities;
using System;
using System.Threading.Tasks;

namespace StatementService.Infrastructure.Persistence
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

            if (!await _context.Statements.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");
                var statements = new[]
                {
                    new Statement
                    {
                        IssueData = DateTime.Now,
                        AccountId = 1
                    },
                    new Statement
                    {
                        IssueData = DateTime.Now,
                        AccountId = 2
                    },
                };

                await _context.Statements.AddRangeAsync(statements);
                _logger.LogInformation("Seeding Statements Done!");
                _logger.LogInformation("Seeding initial data completed");
            }

            await _context.SaveChangesAsync();
        }
    }
}
