using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*Debes colocar el nombre de usuario.*")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Debes colocar la contraseña.*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}