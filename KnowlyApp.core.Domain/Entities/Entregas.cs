using KnowlyApp.Core.Domain.Common;

namespace KnowlyApp.Core.Domain.Entities
{
    public class Entregas : AuditableBaseEntity
    {
        public DateTime FechaEntrega { get; set; }
        public string ArchivosAdjuntos { get; set; }
        public int Calificacion { get; set; }
        public string Comentarios { get; set; }
        public int EstudianteId { get; set; }
        public int TareaId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Estudiantes estudiantes { get; set; }
        public Tareas tareas { get; set; }
    }
}