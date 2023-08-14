using KnowlyApp.Core.Application.ViewModels.Cursos;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface ICursosService : IGenericService<SaveCursosViewModel, CursosViewModel, Cursos>
    {
       public Task EnrollEstudianteInCourse(int cursoId, int estudianteId);
       public Task<List<CursosViewModel>> GetCursosByMaestro(int maestroId);
        public Task UnenrollEstudianteFromCurso(int cursoId, int estudianteId);
        public Task<List<EstudiantesViewModel>> GetEstudiantesEnrolled(int cursoId);
    }
}
