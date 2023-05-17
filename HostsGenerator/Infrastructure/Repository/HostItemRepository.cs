using HostsGenerator.Application.Entities;
using HostsGenerator.Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace HostsGenerator.Infrastructure.Repository
{
    class HostItemRepository : IHostItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public HostItemRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(HostItem item)
        {
            dbContext.HostItems.Add(item);
        }

        public async Task<IEnumerable<HostItem>> GetAllAsync() =>
            await dbContext.HostItems.ToListAsync();

        public async Task<bool> HasHostItemAsync(string domain) =>
             await dbContext.HostItems.Select(i => i.Domain).ContainsAsync(domain);
    }
}
