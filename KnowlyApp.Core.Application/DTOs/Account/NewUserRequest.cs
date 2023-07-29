using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.DTOs.Account
{
    public class NewUserRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]

        public string Apellido { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?#&])[A-Za-z\d$@$!%*#?&]{7,100}[^'\s]", ErrorMessage = "La contraseña debe tener minimo 8 digitos, 1 letra mayuscula, 1 caracter especial($@$!%*?.#&) y al menos 1 numero. Ejemplo Pass123#")]
        [Required]

        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben coincidir.")]

        [Required]

        public string ConfirmPassword { get; set; }
        [Required]

        public string Phone { get; set; }

        public string ? UserType { get; set; }


    }
}
