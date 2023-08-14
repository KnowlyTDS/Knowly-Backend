using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IEstudiantesService : IGenericService<SaveEstudianteViewModel, EstudiantesViewModel, Estudiantes>
    {
        Task<List<EstudiantesViewModel>> GetEstudiantesByCurso(int cursoId);
    }
}