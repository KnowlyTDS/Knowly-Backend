using KnowlyApp.Core.Application.Enums;
using KnowlyApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;


namespace KnowlyApp.Infrastructure.Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Maestro.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Estudiante.ToString()));
        }
    }
}
