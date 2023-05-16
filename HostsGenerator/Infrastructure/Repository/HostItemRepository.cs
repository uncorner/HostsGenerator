using HostsGenerator.Application.Entities;
using HostsGenerator.Application.Repository;

namespace HostsGenerator.Infrastructure.Repository
{
    class HostItemRepository : IHostItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public HostItemRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<HostItem> GetAll() => dbContext.HostItems.ToList();

        public bool HasHostItemWithDomain(string domain) =>
            dbContext.HostItems.Select(i => i.Domain).Contains(domain);
    }
}
