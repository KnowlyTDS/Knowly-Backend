using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Domain.Entities;
using KnowlyApp.Infrastructure.Persistence.Context;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class TareasRepository : GenericRepository<Tareas>, ITareasRepository
    {
        private readonly ApplicationContext _dbContext;

        public TareasRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}