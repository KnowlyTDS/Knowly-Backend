
using AutoMapper;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Cursos;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;

namespace KnowlyApp.Core.Application.Services
{
    public class CursosService : GenericService<SaveCursosViewModel, CursosViewModel, Cursos>, ICursosService
    {
        private readonly ICursosRepository _repository;
        private readonly IEstudiantesRepository _estudiantesRepository;
        private readonly IMapper _mapper;



        public CursosService(ICursosRepository repository, IMapper mapper, IEstudiantesRepository estudiantesRepository) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _estudiantesRepository = estudiantesRepository;
        }

        public async Task<List<CursosViewModel>> GetCursosByMaestro(int maestroId)
        {
            var cursosWithIncludes = await _repository.GetAllWithIncludes(new List<string> { "maestros", "Tareas", "EstudiantesInscritos" });

            var cursosDelMaestro = cursosWithIncludes
                .Where(c => c.MaestroId == maestroId)
                .ToList();

            return _mapper.Map<List<CursosViewModel>>(cursosDelMaestro);
        }

        public async Task EnrollEstudianteInCourse(int cursoId, int estudianteId)
        {
            var estudiante = await _estudiantesRepository.GetViewModelById(estudianteId);
            var curso = await _repository.GetViewModelById(cursoId);
            if (curso != null && estudiante != null)
            {
                if (curso.EstudiantesInscritos == null)
                {
                    curso.EstudiantesInscritos = new List<EstudiantesCursos>();
                }
                curso.EstudiantesInscritos.Add(new EstudiantesCursos { estudiante = estudiante });
            }
            else
            {
                throw new NotFoundException("Estudiante no encontrado.");
            }
            










            await _repository.UpdateAsync(curso, cursoId);
        }

        public async Task<List<EstudiantesViewModel>> GetEstudiantesEnrolled(int cursoId)
        {
            var curso = await _repository.GetByIdWithIncludesAsync(cursoId, new List<string> { "EstudiantesInscritos.estudiante" });

            if (curso == null)
            {
                throw new NotFoundException("Curso no encontrado.");
            }

            var estudiantesInscritos = new List<EstudiantesViewModel>();

            foreach (var estudianteCurso in curso.EstudiantesInscritos)
            {
                if (estudianteCurso.estudiante != null)
                {
                    var estudianteViewModel = _mapper.Map<EstudiantesViewModel>(estudianteCurso.estudiante);
                    estudiantesInscritos.Add(estudianteViewModel);
                }
                else
                {
                    throw new NotFoundException("Estudiante nulo en EstudiantesCursos");
                    
                }
            }

            return estudiantesInscritos;
        }


        public async Task UnenrollEstudianteFromCurso(int cursoId, int estudianteId)
        {
            var curso = await _repository.GetViewModelById(cursoId);
            if (curso == null)
            {
                throw new NotFoundException("Curso no encontrado");
            }

            var estudiante = await _estudiantesRepository.GetViewModelById(estudianteId);
            if (estudiante == null)
            {
                throw new NotFoundException("Estudiante no encontrado");
            }

            var inscripcion = curso.EstudiantesInscritos.FirstOrDefault(e => e.EstudianteId == estudianteId);
            if (inscripcion != null)
            {
                curso.EstudiantesInscritos.Remove(inscripcion);
                await _repository.UpdateAsync(curso, cursoId);
            }
            else
            {
                throw new NotFoundException("El estudiante no está inscrito en este curso");
            }
        }

    }


}
