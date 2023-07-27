using Microsoft.EntityFrameworkCore;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowlyApp.core.Domain.Entities;

namespace KnowlyApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Usuario>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        

    }
}
