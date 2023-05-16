using HostsGenerator.Application.Repository;

namespace HostsGenerator.Infrastructure.Repository
{
    class RepositoryFactory : IRepositoryFactory
    {
        public IHostItemRepository GetHostItemRepository(ApplicationDbContext dbContext) =>
            new HostItemRepository(dbContext);
    }
}
