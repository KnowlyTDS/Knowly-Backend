using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IMaestrosService : IGenericService<SaveMaestroViewModel, MaestroViewModel, Maestros>
    {
        Task<List<MaestroViewModel>> GetMaestrosByEspecialidad(string especialidad);

        Task<List<MaestroViewModel>> GetMaestrosWithCursos(int cursoId);
    }
}