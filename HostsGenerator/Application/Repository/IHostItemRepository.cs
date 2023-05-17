using HostsGenerator.Application.Entities;

namespace HostsGenerator.Application.Repository
{
    public interface IHostItemRepository
    {
        Task<IEnumerable<HostItem>> GetAllAsync();

        Task<bool> HasHostItemAsync(string domain);

        void Add(HostItem item);
        
    }
}
