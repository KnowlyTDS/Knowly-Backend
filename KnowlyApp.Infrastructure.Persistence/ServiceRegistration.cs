using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Infrastructure.Persistence.Context;
using KnowlyApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KnowlyApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Context Configuration"

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("InMemoryDB"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion "Context Configuration"

            #region "Services"

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IEstudiantesRepository, EstudiantesRepository>();
            services.AddTransient<ICursosRepository, CursosRepository>();
            services.AddTransient<IMaestrosRepository, MaestrosRepository>();
            services.AddTransient<ITareasRepository, TareasRepository>();
            services.AddTransient<IEntregasRepository, EntregasRepository>();

            #endregion "Services"
        }
    }
}