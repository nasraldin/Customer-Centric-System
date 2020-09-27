using System.Threading.Tasks;

namespace CustomerService.Core.Common.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
