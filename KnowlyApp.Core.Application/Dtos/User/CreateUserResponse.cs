using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Dtos.User
{
    public class CreateUserResponse
    {
        public bool HasError { get; set; }
        public String Error { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int RolId { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
