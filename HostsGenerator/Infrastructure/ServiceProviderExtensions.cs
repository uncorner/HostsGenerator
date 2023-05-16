using HostsGenerator.Application.Repository;
using HostsGenerator.Infrastructure.Repository;

namespace HostsGenerator.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();
        }

    }
}
