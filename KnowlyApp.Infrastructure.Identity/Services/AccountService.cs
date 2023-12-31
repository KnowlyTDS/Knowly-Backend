﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.Enums;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Users;
using KnowlyApp.Core.Domain.Settings;
using KnowlyApp.Infrastructure.Identity.Entities;
//using KnowlyApp.Core.Application.DTOs.Email;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Application.Dtos.Account;

namespace KnowlyApp.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly JWTSettings _jwtSettings;


        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _jwtSettings = jwtSettings.Value;

        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = new ApplicationUser();
            user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                user = await _userManager.FindByNameAsync(request.Email);
                if (user == null)
                {
                    response.HasError = true;
                    response.Error = $"Cuenta {request.Email} no registrada";
                    return response;
                }
            }



            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);





            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Datos incorrectos para cuenta {request.Email}";
                return response;
            }


            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Cuenta no activada {request.Email}";
                return response;
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = GenerateRefreshToken();
            response.RefreshToken = refreshToken.Token;

            return response;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin)
        {
            RegisterResponse response = new()
            {
                HasError = false
            };

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"username '{request.UserName}' is already taken.";
                return response;
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                response.HasError = true;
                response.Error = $"Email '{request.Email}' is already registered.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                Nombre = request.FirstName,
                Apellido= request.LastName,
                UserName = request.UserName,
                Photo = request.Photo,
                PhoneNumber = request.Phone


            };
            if (request.UserType == Roles.Admin.ToString())
            {
                user.EmailConfirmed = true;
                user.Photo = "Sin Photo";
                user.PhoneNumber = "Sin telefono";
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"An error occurred trying to register the user.";
                return response;


            }
            else
            {
                if (request.UserType == Roles.Estudiante.ToString())
                {
                    await _userManager.AddToRoleAsync(user, Roles.Estudiante.ToString());
                    var verificationUri = await SendVerificationEmailUri(user, origin);
                    
                }
                if (request.UserType == Roles.Maestro.ToString())
                {
                    await _userManager.AddToRoleAsync(user, Roles.Maestro.ToString());

                }
                if (request.UserType == Roles.Admin.ToString())
                {
                    await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());

                }
               
            }


            return response;
        }



        public async Task<string> Activate_Desactivate(string userId, int action)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);


            if (action == 0)
            {
                user.EmailConfirmed = true;
            }
            if (action == 1)
            {
                user.EmailConfirmed = false;
            }
            if (action == 3)
            {
                user.EmailConfirmed = true;
            }
            if (action == 4)
            {
                user.EmailConfirmed = false;
            }



            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return $"Cuenta activada/desactivada";
            }
            else
            {
                return $"Error mientras confirmaba la cuenta.";
            }



        }



        public async Task<string> ConfirmAccountAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return $"No accounts registered with this user";
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return $"Account confirmed for {user.Email}. You can now use the app";
            }
            else
            {
                return $"An error occurred wgile confirming {user.Email}.";
            }
        }


        public async Task ChangePass(RegisterRequest request)
        {
            ApplicationUser User = await _userManager.FindByIdAsync(request.Id);
            var NewPassToken = await _userManager.GeneratePasswordResetTokenAsync(User);

            await _userManager.ResetPasswordAsync(User, NewPassToken, request.Password);
        }

        private async Task<string> SendVerificationEmailUri(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "User/ConfirmEmail";
            var Uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "token", code);

            return verificationUri;
        }


        public async Task<List<MaestroViewModel>> GetAllMaestros()
        {
            List<MaestroViewModel> maestroViewModels = new();
            var Users = _userManager.GetUsersInRoleAsync(Roles.Maestro.ToString()).Result.OrderBy(n => n.Nombre);

            foreach (var user in Users)
            {
                if (user.EmailConfirmed == true)
                {
                    MaestroViewModel agentView = new();
                    agentView.Nombre = user.Nombre;
                    agentView.Apellido = user.Apellido;
                    agentView.Id = user.Id;
                    agentView.Photo = user.Photo;
                    agentView.Email = user.Email;
                    agentView.isActive = user.EmailConfirmed;
                    agentView.Tel = user.PhoneNumber;


                    maestroViewModels.Add(agentView);
                }
            }

            return maestroViewModels;
        }

        public async Task<List<EstudiantesViewModel>> GetAllEstudiantes()
        {
            List<EstudiantesViewModel> estudianteViewModels = new();
            var Users = _userManager.GetUsersInRoleAsync(Roles.Maestro.ToString()).Result.OrderBy(n => n.Nombre);

            foreach (var user in Users)
            {
                if (user.EmailConfirmed == true)
                {
                    EstudiantesViewModel agentView = new();
                    agentView.Nombre = user.Nombre;
                    agentView.Apellido = user.Apellido;
                    agentView.Id = user.Id;
                    agentView.Photo = user.Photo;
                    agentView.Email = user.Email;
                    agentView.isActive = user.EmailConfirmed;
                    agentView.Tel = user.PhoneNumber;


                    estudianteViewModels.Add(agentView);
                }
            }

            return estudianteViewModels;
        }

        public async Task<List<UserViewModel>> GetAllAdmin(string role)
        {
            List<UserViewModel> agentViewModels = new();
            var Users = await _userManager.GetUsersInRoleAsync(role);
            foreach (var user in Users)
            {
                UserViewModel newuser = new();
                var userView = await _userManager.FindByIdAsync(user.Id);
                newuser.Nombre = userView.Nombre;
                newuser.Nombre = userView.Nombre;
                newuser.Email = userView.Email;
                newuser.UserName = userView.UserName;
                newuser.EmailConfirm = userView.EmailConfirmed;
                newuser.Id = userView.Id;
                newuser.Phone = userView.PhoneNumber;
                agentViewModels.Add(newuser);




            }



            return agentViewModels;
        }




        public async Task Edit(RegisterRequest request, string role)
        {
            ApplicationUser User = await _userManager.FindByIdAsync(request.Id);

            if (role == "New")
            {
                User.Photo= request.Photo;
                await _userManager.UpdateAsync(User);
            }


            if (role == Roles.Maestro.ToString())
            {
                User.Nombre = request.FirstName;
                User.Apellido = request.LastName;
                User.PhoneNumber = request.Phone;
                User.Photo = request.Photo;
                await _userManager.UpdateAsync(User);

            }

            if (role == Roles.Admin.ToString())
            {
                User.Nombre = request.FirstName;
                User.Apellido = request.LastName;
                User.UserName = request.UserName;
                User.Email = request.Email;
                await _userManager.UpdateAsync(User);


            }
            



        }

        public async Task<RegisterRequest> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            RegisterRequest response = new();
            response.Id = user.Id;
            response.UserName = user.UserName;
            response.LastName = user.Nombre;
            response.FirstName = user.Apellido;
            response.Photo = user.Photo;
            response.Password = user.PasswordHash;
            response.Email = user.Email;
            response.Phone = user.PhoneNumber;




            return response;
        }

        public async Task<RegisterRequest> GetUserByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            RegisterRequest response = new();
            response.Id = user.Id;
            response.UserName = user.UserName;
            response.LastName = user.Apellido;
            response.FirstName = user.Nombre;
            response.Photo = user.Photo;
            response.Password = user.PasswordHash;
            response.Email = user.Email;
            response.Phone = user.PhoneNumber;


            return response;
        }

        public async Task<int> GetUserCount(string role, bool active)
        {
            var Users = _userManager.GetUsersInRoleAsync(role).Result;
            List<int> count = new List<int>();
            if (active)
            {
                foreach (var user in Users.Where(u => u.EmailConfirmed == true))
                {
                    count.Add(1);
                }
            }

            if (!active)
            {
                foreach (var user in Users.Where(u => u.EmailConfirmed == false))
                {
                    count.Add(1);
                }
            }

            return count.Count;
        }

        public async Task DeleteMaestro(string Id)
        {
            ApplicationUser application = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(application);

        }

        public async Task<string> GetRole(string Id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ElementAtOrDefault(0).ToString();
        }



        #region PrivateMethods

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmectricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredetials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredetials);

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var ramdomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(ramdomBytes);

            return BitConverter.ToString(ramdomBytes).Replace("-", "");
        }





        #endregion
    }


}

