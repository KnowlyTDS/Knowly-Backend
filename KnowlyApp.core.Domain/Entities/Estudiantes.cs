using KnowlyApp.Core.Domain.Common;

namespace KnowlyApp.Core.Domain.Entities
{
    public class Estudiantes : AuditableBaseEntity
    {
        public string Email { get; set; }

        public string Foto { get; set; }

        public string Tel { get; set; }

        public string Genero { get; set; }

        public int CantidadTareas { get; set; }

        public bool isActive { get; set; }

        public List<EstudiantesCursos> Cursos { get; set; }
        public List<Entregas> entregas { get; set; }
    }
}