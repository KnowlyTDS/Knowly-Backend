using KnowlyApp.Core.Application.ViewModels.Entregas;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IEntregasService : IGenericService<SaveEntregaViewModel, EntregaViewModel, Entregas>
    {
        Task<List<EntregaViewModel>> GetEntregasByEstudianteId(int estudianteId);

        Task<List<EntregaViewModel>> GetEntregasByTareaIdAsync(int tareaId);

        Task<List<EntregaViewModel>> GetEntregasPendientesAsync();

        Task<EntregaViewModel> CalificarEntregaAsync(int entregaId, int calificacion, string comentarios);

        Task<List<EntregaViewModel>> GetEntregasByFechaAsync(DateTime fecha);
    }
}