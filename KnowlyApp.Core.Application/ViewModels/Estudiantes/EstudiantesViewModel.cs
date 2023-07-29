using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.ViewModels.Estudiantes
{
    public class EstudiantesViewModel
    {
        public string Id { get; set; }
        public string Tel { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }
    }
}
