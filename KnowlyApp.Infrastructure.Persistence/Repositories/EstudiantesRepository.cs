using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Domain.Entities;
using KnowlyApp.Infrastructure.Persistence.Context;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class EstudiantesRepository : GenericRepository<Estudiantes>, IEstudiantesRepository
    {
        private readonly ApplicationContext _dbContext;

        public EstudiantesRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}