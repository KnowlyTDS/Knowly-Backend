using KnowlyApp.Core.Application.Dtos.Account;

namespace KnowlyApp.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        

    }
}