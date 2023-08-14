using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Domain.Entities;
using KnowlyApp.Infrastructure.Persistence.Context;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class EntregasRepository : GenericRepository<Entregas>, IEntregasRepository
    {
        private readonly ApplicationContext _dbContext;

        public EntregasRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}