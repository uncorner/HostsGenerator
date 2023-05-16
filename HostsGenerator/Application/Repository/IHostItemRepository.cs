using HostsGenerator.Application.Entities;

namespace HostsGenerator.Application.Repository
{
    public interface IHostItemRepository
    {
        IEnumerable<HostItem> GetAll();
        
        bool HasHostItemWithDomain(string domain);
        
    }
}
