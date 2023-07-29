﻿
using Microsoft.AspNetCore.Identity;
using KnowlyApp.Infrastructure.Identity.Entities;
using KnowlyApp.Core.Application.Enums;

namespace KnowlyApp.Infrastructure.Identity.Seeds
{
    public class DefaultEstudiante
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser users = new();

            users.Nombre = "Jhon";
            users.Apellido = "Doe";
            users.UserName = "estudianteuser";
            users.Email = "student@gmail.com";
            users.Photo = "https://media.istockphoto.com/id/1300845620/vector/user-icon-flat-isolated-on-white-background-user-symbol-vector-illustration.jpg?s=612x612&w=0&k=20&c=yBeyba0hUkh14_jgv1OKqIH0CCSWU_4ckRkAoy2p73o=";
            users.EmailConfirmed = true;
            users.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != users.Id))
            {
                await userManager.CreateAsync(users, "123Pa$$");
                await userManager.AddToRoleAsync(users, Roles.Estudiante.ToString());



            }
        }

    }
}
