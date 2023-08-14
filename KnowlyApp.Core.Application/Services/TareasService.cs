using AutoMapper;
using KnowlyApp.Core.Application.DTOs.Email;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Tareas;
using KnowlyApp.Core.Domain.Entities;

namespace KnowlyApp.Core.Application.Services
{
    public class TareasService : GenericService<SaveTareaViewModel, TareaViewModel, Tareas>, ITareasService
    {
        private readonly IEmailService _emailService;
        private readonly IEstudiantesService _estudiantesService;
        private readonly IMapper _mapper;
        private readonly ITareasRepository _tareasRepository;

        public TareasService(ITareasRepository tareasRepository, IMapper mapper, IEmailService emailService, IEstudiantesService estudiantesService) : base(tareasRepository, mapper)
        {
            _tareasRepository = tareasRepository;
            _emailService = emailService;
            _mapper = mapper;
            _estudiantesService = estudiantesService;
        }

        public async Task CalificarTareaAsync(int tareaId, int puntaje)
        {
            var tarea = await _tareasRepository.GetViewModelById(tareaId);
            if (tarea != null)
            {
                // Lógica de calificación basada en el puntaje
                tarea.PuntuacionMaxima = puntaje;

                await _tareasRepository.UpdateAsync(tarea, tareaId);
            }
            if (tarea != null && tarea.FechaVencimiento > DateTime.Now)
            {
                await SendTareaPendienteNotificationAsync(tarea.EstudianteId, tarea.Id);
            }
        }

        public async Task<List<TareaViewModel>> GetTareasByCursoId(int cursoId)
        {
            // método en _tareasRepository que obtiene tareas por el ID del curso
            var tareasPorCurso = await _tareasRepository.GetAllViewModel();

            // Filtrar las tareas por el ID del curso
            var tareasDelCurso = tareasPorCurso
                .Where(t => t.CursoId == cursoId)
                .Select(t => _mapper.Map<TareaViewModel>(t))
                .ToList();

            return tareasDelCurso;
        }

        public async Task<List<TareaViewModel>> GetTareasByEstudianteId(int estudianteId)
        {
            var tareasPorEstudiante = await _tareasRepository.GetAllViewModel();

            var tareasDelEstudiante = tareasPorEstudiante
                .Where(t => t.EstudianteId == estudianteId)
                .Select(t => _mapper.Map<TareaViewModel>(t))
                .ToList();

            return tareasDelEstudiante;
        }

        public async Task SendTareaPendienteNotificationAsync(int estudianteId, int tareaId)
        {
            var estudiante = await _estudiantesService.GetByIdSaveViewModel(estudianteId);
            if (estudiante != null)
            {
                await _emailService.SendAsync(new EmailRequest()
                {
                    To = estudiante.Email,
                    Body = $"Por favor completa tu tarea pendiente con el ID {tareaId}. No olvides entregarla a tiempo.",
                    Subject = "Correo de confirmacion"
                });
            }
        }
    }
}