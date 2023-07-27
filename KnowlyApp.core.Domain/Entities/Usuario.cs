using KnowlyApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.core.Domain.Entities
{
    public class Usuario : AuditableBaseEntity
    {

        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int RolId { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

    }
}
