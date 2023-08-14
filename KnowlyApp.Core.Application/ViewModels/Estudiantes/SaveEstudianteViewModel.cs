using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Estudiantes
{
    public class SaveEstudianteViewModel
    {
        public int? id { get; set; }

        [RegularExpression(@"^\+[1-1]\([8-8]\d{1}[9-9]\)-\d{3}\-\d{4}$", ErrorMessage = "Telefono no valido Ejemplo de telefono +1(8x9)-xxx-xxxx")]
        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre no debe tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El apellido no debe tener más de 50 caracteres.")]
        public string Apellido { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "El campo Correo Genero es requerido.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        public bool isActive { get; set; }

        public int CantidadTareas { get; set; }

        public int CantidadCursos { get; set; }

        public int CantidadEntregas { get; set; }
    }
}