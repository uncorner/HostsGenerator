using HostsGenerator.Infrastructure;

namespace HostsGenerator.Application.Repository
{
    public interface IRepositoryFactory
    {
        IHostItemRepository GetHostItemRepository(ApplicationDbContext dbContext);
    }
}
