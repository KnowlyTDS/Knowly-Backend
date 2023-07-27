using KnowlyApp.Core.Application.Dtos.Account;
using KnowlyApp.Core.Application.Dtos.User;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IUserService 
    {
        Task<AuthenticationResponse> LoginAsync(AuthenticationRequest vm);
        Task<CreateUserResponse> RegisterAsync(CreateUserRequest vm);
    }
}
