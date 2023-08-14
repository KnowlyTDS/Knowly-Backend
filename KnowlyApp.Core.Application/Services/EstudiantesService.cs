using AutoMapper;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Services
{
    public class EstudiantesService : GenericService<SaveEstudianteViewModel, EstudiantesViewModel, Estudiantes>, IEstudiantesService
    {
        private readonly IAccountService _accountService;
        private readonly IEstudiantesRepository _repository;
        private readonly IMapper _mapper;

        public EstudiantesService(IEstudiantesRepository repository, IAccountService accountService, IMapper mapper) : base(repository, mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<EstudiantesViewModel>> GetAllViewModel()
        {
            var estudiantes = await _repository.GetAllViewModel();
            return _mapper.Map<List<EstudiantesViewModel>>(estudiantes);
        }

        public async Task<EstudiantesViewModel> GetEstudianteByIdAsync(int estudianteId)
        {
            var estudiante = await _repository.GetViewModelById(estudianteId);
            return _mapper.Map<EstudiantesViewModel>(estudiante);
        }

        public async Task<List<EstudiantesViewModel>> GetAllWithIncludes(List<string> properties)
        {
            var estudiantes = await _repository.GetAllWithIncludes(properties);
            return _mapper.Map<List<EstudiantesViewModel>>(estudiantes);
        }

        public async Task<List<EstudiantesViewModel>> GetEstudiantesByCurso(int cursoId)
        {
            // Obtener todos los estudiantes con los cursos relacionados incluidos
            var estudiantesWithCursos = await _repository.GetAllWithIncludes(new List<string> { "Cursos" });

            // Filtrar los estudiantes por el curso específico
            var estudiantesDelCurso = estudiantesWithCursos
                .Where(e => e.Cursos.Any(c => c.Id == cursoId))
                .ToList();

            return _mapper.Map<List<EstudiantesViewModel>>(estudiantesDelCurso);
        }
    }
}