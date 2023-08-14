using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Entregas
{
    public class SaveEntregaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es requerida.")]
        [Display(Name = "Fecha de Entrega")]
        public DateTime FechaEntrega { get; set; }

        [Display(Name = "Archivos Adjuntos")]
        public string ArchivosAdjuntos { get; set; }

        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]
        public int Calificacion { get; set; }

        [StringLength(500, ErrorMessage = "Los comentarios no deben tener más de 500 caracteres.")]
        public string Comentarios { get; set; }

        [Required(ErrorMessage = "El campo Estudiante es requerido.")]
        [Display(Name = "Estudiante")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El campo Tarea es requerido.")]
        [Display(Name = "Tarea")]
        public int TareaId { get; set; }
    }
}