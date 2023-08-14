using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Users;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<string> Activate_Desactivate(string userId, int action);

        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);

        Task ChangePass(RegisterRequest request);

        Task<string> ConfirmAccountAsync(string userId, string token);

        Task DeleteEstudiante(string Id);

        Task DeleteMaestro(string Id);

        Task Edit(RegisterRequest request, string role);

        Task<List<UserViewModel>> GetAllAdmin(string role);

        Task<List<EstudiantesViewModel>> GetAllEstudiantes();

        Task<List<MaestroViewModel>> GetAllMaestros();

        Task<string> GetRole(string Id);

        Task<RegisterRequest> GetUserById(string id);

        Task<RegisterRequest> GetUserByName(string name);

        Task<int> GetUserCount(string role, bool active);

        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);

        Task SignOutAsync();
    }
}