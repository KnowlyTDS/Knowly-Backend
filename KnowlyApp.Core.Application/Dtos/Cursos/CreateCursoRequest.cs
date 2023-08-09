using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Dtos.Cursos
{
    public class CreateCursoRequest
    {
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string Instructor { get; set; }
        public int Duracion { get; set; }
        public string Nivel { get; set; }
        public string Categoria { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string Requisitos { get; set; }
        public string Idioma { get; set; }
        public string? Materiales { get; set; }
        public bool Certificacion { get; set; }
    }
}
