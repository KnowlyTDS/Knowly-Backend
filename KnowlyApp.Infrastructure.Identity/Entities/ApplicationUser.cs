using Microsoft.AspNetCore.Identity;

namespace KnowlyApp.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Photo { get; set; }
    }
}