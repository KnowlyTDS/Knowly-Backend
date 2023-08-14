using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Tareas
{
    public class SaveTareaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Título es requerido.")]
        [StringLength(100, ErrorMessage = "El título no debe tener más de 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        [StringLength(500, ErrorMessage = "La descripción no debe tener más de 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Creación es requerido.")]
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Vencimiento es requerido.")]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La puntuación máxima debe ser un número positivo.")]
        public int PuntuacionMaxima { get; set; }

        [Required(ErrorMessage = "El campo Curso es requerido.")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "El campo Maestro es requerido.")]
        [Display(Name = "Maestro")]
        public int MaestroId { get; set; }
    }
}