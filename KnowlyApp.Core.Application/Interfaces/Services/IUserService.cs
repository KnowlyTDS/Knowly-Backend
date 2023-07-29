using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Users;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task Edit(SaveUserViewModel vm, string role);

         Task<EditUserViewModel> EditId(string Id);
        Task DeleteMaestro(string Id);
        Task<SaveUserViewModel> GetUserByName(string Name);
        Task<PassUserViewModel> GetChengePassId(string id);
        Task<PassUserViewModel> ChangePass(PassUserViewModel vm);

        Task<SaveUserViewModel> GetUserById(string id);

        Task<List<MaestroViewModel>> GetAllMaestros();

        Task EditAdmin(EditUserViewModel vm, string role);
        Task<RegisterResponse> RegisterAdmin(SaveAdminViewModel vm, string origin);

        Task<List<UserViewModel>> GetAllAdmin(string role);

        Task<string> Activate_Disactivate(string UserId, int action);

        Task<IndexAdminViewModel> GetAllInfo();
        Task SignOutAsync();
    }
}