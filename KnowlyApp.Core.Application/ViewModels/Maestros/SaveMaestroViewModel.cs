using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.ViewModels.Maestros
{
    public class SaveMaestroViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }


        public IFormFile? ProfilePic { get; set; }
        public string? Photo { get; set; }


        [RegularExpression(@"^\+[1-1]\([8-8]\d{1}[9-9]\)-\d{3}\-\d{4}$", ErrorMessage = "Telefono no valido Ejemplo de telefono +1(8x9)-xxx-xxxx")]
        [Required(ErrorMessage = "*Obligado*")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }

    }
}
