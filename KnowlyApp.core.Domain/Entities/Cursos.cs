

namespace KnowlyApp.Core.Domain.Entities
{
    public class Cursos 
    {
        public virtual int Id { get; set; }
        public string Descripcion { get; set; }
        public string Horario { get; set; }

        // Navigation property
        public List<Tareas> Tareas { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int MaestroId { get; set; }
        public Maestros maestros { get; set; }
        public List<EstudiantesCursos> EstudiantesInscritos { get; set; }

    }
}