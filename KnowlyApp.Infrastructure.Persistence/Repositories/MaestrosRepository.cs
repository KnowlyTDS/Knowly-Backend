using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Domain.Entities;
using KnowlyApp.Infrastructure.Persistence.Context;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class MaestrosRepository : GenericRepository<Maestros>, IMaestrosRepository
    {
        private readonly ApplicationContext _dbContext;

        public MaestrosRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}