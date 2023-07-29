
namespace KnowlyApp.Core.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public bool EmailConfirm { get; set; }
        public string IdCard { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public int tareas { get; set; }
        public List<string> Roles { get; set; }
    }
}
