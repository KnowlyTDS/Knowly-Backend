using KnowlyApp.Core.Domain.Common;

namespace KnowlyApp.Core.Domain.Entities
{
    public class EstudiantesCursos 
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public Estudiantes estudiante { get; set; }

        public int CursoId { get; set; }
        public Cursos Curso { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }




    }
}