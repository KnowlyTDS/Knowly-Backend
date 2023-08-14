using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Users;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> Activate_Disactivate(string UserId, int action);

        Task<PassUserViewModel> ChangePass(PassUserViewModel vm);

        Task<string> ConfirmEmailAsync(string userId, string token);

        Task DeleteMaestro(string Id);

        Task Edit(SaveUserViewModel vm, string role);

        Task EditAdmin(EditUserViewModel vm, string role);

        Task<EditUserViewModel> EditId(string Id);

        Task<List<UserViewModel>> GetAllAdmin(string role);

        Task<IndexAdminViewModel> GetAllInfo();

        Task<List<MaestroViewModel>> GetAllMaestros();

        Task<PassUserViewModel> GetChengePassId(string id);

        Task<SaveUserViewModel> GetUserById(string id);

        Task<SaveUserViewModel> GetUserByName(string Name);

        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);

        Task<RegisterResponse> RegisterAdmin(SaveAdminViewModel vm, string origin);

        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);

        Task SignOutAsync();
    }
}