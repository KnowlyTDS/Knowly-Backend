using System.ComponentModel.DataAnnotations;

namespace KnowlyApp.Core.Application.ViewModels.Maestros
{
    public class MaestroViewModel
    {
        public string Id { get; set; }

        public string Nombre { get; set; }


        public string Apellido { get; set; }

        public string Email { get; set; }


        public string? Photo { get; set; }

        public string Tel { get; set; }

        public bool isActive { get; set; }


        public string Genero { get; set; }

        public int cantCursosImpartidos { get; set; }

        public string Especialidad { get; set; }
    }
}