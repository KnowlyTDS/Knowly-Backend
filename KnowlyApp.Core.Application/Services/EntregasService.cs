using AutoMapper;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Entregas;
using KnowlyApp.Core.Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace KnowlyApp.Core.Application.Services
{
    public class EntregasService : GenericService<SaveEntregaViewModel, EntregaViewModel, Entregas>, IEntregasService
    {
        private readonly IEntregasRepository _entregasRepository;
        private readonly IMapper _mapper;
        //private readonly IEntregasService _entregasService;

        public EntregasService(IEntregasRepository entregasRepository, IMapper mapper) : base(entregasRepository, mapper)
        {
            _entregasRepository = entregasRepository;
            _mapper = mapper;
        }

        public async Task<List<EntregaViewModel>> GetEntregasByEstudianteId(int estudianteId)
        {
            var entregasPorEstudiante = await _entregasRepository.GetAllViewModel();
            var entregasDelEstudiante = entregasPorEstudiante
                .Where(e => e.EstudianteId == estudianteId)
                .Select(e => _mapper.Map<EntregaViewModel>(e))
                .ToList();

            return entregasDelEstudiante;
        }

        public async Task<List<EntregaViewModel>> GetEntregasByTareaIdAsync(int tareaId)
        {
            var entregas = await GetEntregasByTareaIdAsync(tareaId);
            return _mapper.Map<List<EntregaViewModel>>(entregas);
        }

        public async Task<List<EntregaViewModel>> GetEntregasPendientesAsync()
        {
            var entregasPendientes = await GetEntregasPendientesAsync();
            return _mapper.Map<List<EntregaViewModel>>(entregasPendientes);
        }

        public async Task<EntregaViewModel> CalificarEntregaAsync(int entregaId, int calificacion, string comentarios)
        {
            var entrega = await _entregasRepository.GetViewModelById(entregaId);

            if (entrega == null)
            {
                throw new NotFoundException("La entrega no fue encontrada");
            }

            entrega.Calificacion = calificacion;
            entrega.Comentarios = comentarios;

            await _entregasRepository.UpdateAsync(entrega, entregaId);

            return _mapper.Map<EntregaViewModel>(entrega);
        }

        public async Task<EntregaViewModel> GetEntregaByIdAsync(int entregaId)
        {
            var entrega = await _entregasRepository.GetViewModelById(entregaId);

            if (entrega == null)
            {
                throw new NotFoundException("La entrega no fue encontrada");
            }

            return _mapper.Map<EntregaViewModel>(entrega);
        }

        public async Task<List<EntregaViewModel>> GetEntregasByFechaAsync(DateTime fecha)
        {
            var entregas = await GetEntregasByFechaAsync(fecha);
            return _mapper.Map<List<EntregaViewModel>>(entregas);
        }
    }
}