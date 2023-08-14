using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Domain.Entities;
using KnowlyApp.Infrastructure.Persistence.Context;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class CursosRepository : GenericRepository<Cursos>, ICursosRepository
    {
        private readonly ApplicationContext _dbContext;

        public CursosRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}