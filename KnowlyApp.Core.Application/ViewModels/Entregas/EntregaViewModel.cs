namespace KnowlyApp.Core.Application.ViewModels.Entregas
{
    public class EntregaViewModel
    {
        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string ArchivosAdjuntos { get; set; }
        public int Calificacion { get; set; }
        public string Comentarios { get; set; }
        public int EstudianteId { get; set; }
        public int TareaId { get; set; }
    }
}