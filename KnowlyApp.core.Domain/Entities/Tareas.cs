using KnowlyApp.Core.Domain.Common;

namespace KnowlyApp.Core.Domain.Entities
{
    public class Tareas : AuditableBaseEntity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int PuntuacionMaxima { get; set; }
        public int CursoId { get; set; }
        public int MaestroId { get; set; }
        public int EstudianteId { get; set; }
        public Estudiantes estudiantes { get; set; }
        public Cursos curso { get; set; }
        public Maestros Maestro { get; set; }
        public List<Entregas> Entregas { get; set; }
    }
}