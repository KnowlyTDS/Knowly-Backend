namespace KnowlyApp.Core.Application.ViewModels.Tareas
{
    public class TareaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int PuntuacionMaxima { get; set; }
        public int CursoId { get; set; }
        public int MaestroId { get; set; }
    }
}