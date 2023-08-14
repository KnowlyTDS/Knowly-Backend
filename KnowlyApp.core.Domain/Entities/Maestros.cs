using KnowlyApp.Core.Domain.Common;

namespace KnowlyApp.Core.Domain.Entities
{
    public class Maestros : AuditableBaseEntity
    {
        public string Especialidad { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        public string Photo { get; set; }
        public string Genero { get; set; }
        public int cantCursosImpartidos { get; set; }
        public bool isActive { get; set; }

        // Navigation property
        public List<Cursos> CursosImpartidos { get; set; }

        public List<Tareas> TareasCalificadas { get; set; }
    }
}