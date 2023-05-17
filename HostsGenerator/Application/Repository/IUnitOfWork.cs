namespace HostsGenerator.Application.Repository
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IHostItemRepository CreateHostItemRepository();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}