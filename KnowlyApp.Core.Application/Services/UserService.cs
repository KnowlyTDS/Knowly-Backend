using AutoMapper;
using KnowlyApp.Core.Application.DTOs.Account;
using KnowlyApp.Core.Application.Enums;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using KnowlyApp.Core.Application.ViewModels.Maestros;
using KnowlyApp.Core.Application.ViewModels.Users;


namespace KnowlyApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
            
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
            return userResponse;
        }
        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }
        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin)
        {
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountService.RegisterBasicUserAsync(registerRequest, origin);
        }

        public async Task<RegisterResponse> RegisterAdmin(SaveAdminViewModel vm, string origin)
        {
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountService.RegisterBasicUserAsync(registerRequest, origin);
        }
        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountService.ConfirmAccountAsync(userId, token);
        }

        public async Task Edit(SaveUserViewModel vm, string role)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(vm);

            await _accountService.Edit(request, role);
        }

        public async Task EditAdmin(EditUserViewModel vm, string role)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(vm);

            await _accountService.Edit(request, role);
        }

        public async Task<SaveUserViewModel> GetUserById(string id)
        {
            RegisterRequest user = await _accountService.GetUserById(id);
            SaveUserViewModel vm = _mapper.Map<SaveUserViewModel>(user);
            return vm;
        }

        public async Task<SaveUserViewModel> GetUserByName(string Name)
        {
            RegisterRequest user = await _accountService.GetUserByName(Name);
            SaveUserViewModel vm = _mapper.Map<SaveUserViewModel>(user);
            return vm;
        }


        public async Task<List<MaestroViewModel>> GetAllMaestros()
        {
            return await _accountService.GetAllMaestros();
        }


        public async Task<List<UserViewModel>> GetAllAdmin(string role)
        {
            return await _accountService.GetAllAdmin(role);
        }

        public async Task<string> Activate_Disactivate(string UserId, int action)
        {
            return await _accountService.Activate_Desactivate(UserId, action);
        }

        public async Task<PassUserViewModel> ChangePass(PassUserViewModel vm)
        {
            RegisterRequest request = new();
            request.Password = vm.Password;
            request.Id = vm.Id;
            await _accountService.ChangePass(request);
            vm.HasError = false;
            vm.Error = "Contraseña Actualizada Correctamente";
            vm.Id = vm.Id;
            return vm;
        }

        public async Task<PassUserViewModel> GetChengePassId(string id)
        {
            RegisterRequest user = await _accountService.GetUserById(id);
            PassUserViewModel vm = new();

            vm.HasError = false;
            vm.Id = user.Id;
            return vm;
        }

        public async Task<IndexAdminViewModel> GetAllInfo()
        {
            IndexAdminViewModel indexAdminView = new();
            

            
            indexAdminView.estudianteActive = await _accountService.GetUserCount(Roles.Estudiante.ToString(), true);
            indexAdminView.estudianteUnactive = await _accountService.GetUserCount(Roles.Estudiante.ToString(), false);
            indexAdminView.maestroActive = await _accountService.GetUserCount(Roles.Maestro.ToString(), true);
            indexAdminView.maestroUnactive = await _accountService.GetUserCount(Roles.Maestro.ToString(), false);
           return indexAdminView;



        }


        public async Task<EditUserViewModel> EditId(string Id)
        {
            RegisterRequest user = await _accountService.GetUserById(Id);
            EditUserViewModel viewModel = _mapper.Map<EditUserViewModel>(user);
            viewModel.Role = await _accountService.GetRole(Id);
            return viewModel;
        }

        public async Task DeleteMaestro(string Id)
        {
            await _accountService.DeleteMaestro(Id);
            

        }
    }
}
