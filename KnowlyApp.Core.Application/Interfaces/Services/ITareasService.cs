using KnowlyApp.Core.Application.ViewModels.Tareas;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface ITareasService : IGenericService<SaveTareaViewModel, TareaViewModel, Tareas>
    {
        Task<List<TareaViewModel>> GetTareasByEstudianteId(int estudianteId);

        Task<List<TareaViewModel>> GetTareasByCursoId(int cursoId);

        Task CalificarTareaAsync(int tareaId, int puntaje);

        Task SendTareaPendienteNotificationAsync(int estudianteId, int tareaId);
    }
}