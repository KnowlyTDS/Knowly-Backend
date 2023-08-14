using AutoMapper;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Services
{
    public class MaestrosService : GenericService<SaveMaestroViewModel, MaestroViewModel, Maestros>, IMaestrosService
    {
        private readonly IMaestrosRepository _repository;
        private readonly IMapper _mapper;

        public MaestrosService(IMaestrosRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MaestroViewModel>> GetMaestrosByEspecialidad(string especialidad)
        {
            // Obtener todos los maestros con las propiedades relacionadas incluidas
            var maestrosWithIncludes = await _repository.GetAllViewModel();

            // Filtrar los maestros por la especialidad especificada
            var maestrosByEspecialidad = maestrosWithIncludes
                .Where(m => m.Especialidad == especialidad)
                .ToList();

            return _mapper.Map<List<MaestroViewModel>>(maestrosByEspecialidad);
        }

        public async Task<List<MaestroViewModel>> GetMaestrosWithCursos(int cursoId)
        {
            // Obtener todos los maestros con los cursos impartidos incluidos
            var maestrosWithCursos = await _repository.GetAllWithIncludes(new List<string> { "CursosImpartidos" });

            // Filtrar los maestros por el curso específico
            var maestrosDelCurso = maestrosWithCursos
                .Where(m => m.CursosImpartidos.Any(c => c.Id == cursoId))
                .ToList();

            return _mapper.Map<List<MaestroViewModel>>(maestrosDelCurso);
        }

        // Otros métodos que puedas necesitar
    }
}