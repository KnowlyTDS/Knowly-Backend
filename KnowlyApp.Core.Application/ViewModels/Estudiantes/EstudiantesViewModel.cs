namespace KnowlyApp.Core.Application.ViewModels.Estudiantes
{
    public class EstudiantesViewModel
    {
        public string Id { get; set; }
        public string Tel { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }
        public int CantidadTareas { get; set; }
    }
}