using System.Threading.Tasks;

namespace StatementService.Core.Common.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
