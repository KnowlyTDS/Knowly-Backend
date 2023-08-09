using KnowlyApp.core.Domain.Entities;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        private readonly ApplicationContext _dbContext;

        public CursoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
