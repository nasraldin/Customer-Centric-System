using StatementService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace StatementService.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Statement> Statements { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
