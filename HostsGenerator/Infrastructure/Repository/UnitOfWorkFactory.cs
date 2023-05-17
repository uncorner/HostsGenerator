using HostsGenerator.Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace HostsGenerator.Infrastructure.Repository
{
    class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

        public UnitOfWorkFactory(IDbContextFactory<ApplicationDbContext> dbContextFactory) {
            this.dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork CreateUnitOfWork() => new UnitOfWork(dbContextFactory.CreateDbContext());

    }
}
