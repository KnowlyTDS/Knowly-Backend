using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Maestros
{
    public class SaveMaestroViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        //public IFormFile? ProfilePic { get; set; }
        public string? Photo { get; set; }

        [RegularExpression(@"^\+[1-1]\([8-8]\d{1}[9-9]\)-\d{3}\-\d{4}$", ErrorMessage = "Telefono no valido Ejemplo de telefono +1(8x9)-xxx-xxxx")]
        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        public bool isActive { get; set; }

        [Required(ErrorMessage = "El campo Correo Genero es requerido.")]
        public string Genero { get; set; }

        public int cantCursosImpartidos { get; set; }
        public string Especialidad { get; set; }
    }
}