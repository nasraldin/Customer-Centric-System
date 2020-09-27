using System.Threading.Tasks;

namespace AccountService.Core.Common.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
