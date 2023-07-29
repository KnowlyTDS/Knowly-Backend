
using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Users;


namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);

        Task<string> GetRole(string Id);
        Task DeleteMaestro(string Id);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);

        Task SignOutAsync();

        Task<int> GetUserCount(string role, bool active);

        Task<RegisterRequest> GetUserByName(string name);

        Task Edit(RegisterRequest request, string role);

        Task<List<MaestroViewModel>> GetAllMaestros();

        Task<List<EstudiantesViewModel>> GetAllEstudiantes();

        Task<List<UserViewModel>> GetAllAdmin(string role);

        Task ChangePass(RegisterRequest request);
        Task<RegisterRequest> GetUserById(string id);

        Task<string> Activate_Desactivate(string userId, int action);

    }
}
