using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KnowlyApp.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IEstudiantesService, EstudiantesService>();
            service.AddTransient<ITareasService, TareasService>();
            service.AddTransient<IEntregasService, EntregasService>();
            service.AddTransient<IMaestrosService, MaestrosService>();
            service.AddTransient<ICursosService, CursosService>();
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}