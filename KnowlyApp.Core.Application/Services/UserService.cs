using KnowlyApp.core.Domain.Entities;
using KnowlyApp.Core.Application.Dtos.Account;
using KnowlyApp.Core.Application.Dtos.User;
using KnowlyApp.Core.Application.Interfaces.Repositories;
using KnowlyApp.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iuserRepository;
        public UserService(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<AuthenticationResponse> LoginAsync(AuthenticationRequest vm)
        {

            var list = await _iuserRepository.GetAllAsync();
            var temp = list.FirstOrDefault(x => x.Clave == vm.Password && x.Correo == vm.Email);
            if (temp != null)
            {
                return new AuthenticationResponse
                {
                    Email = temp.Correo,
                    HasError = false,
                    IsVerified = true,
                    UserName = temp.Nombre
                };
            }

            throw new Exception("Datos incorrectos.");
        }

        public async Task<CreateUserResponse> RegisterAsync(CreateUserRequest vm)
        {
           
                var userAdd = new Usuario
                {
                    Nombre = vm.Nombre,
                    Apellido = vm.Apellido,
                    Clave = vm.Clave,
                    Correo = vm.Correo,
                    Direccion = vm.Direccion,
                    Telefono = vm.Telefono,
                    RolId = vm.RolId,
                    
                    Created = DateTime.Now
                };
                var tem = await _iuserRepository.AddAsync(userAdd);
                var res = new CreateUserResponse
                    {
                     Nombre = vm.Nombre,
                    Apellido = vm.Apellido,
                    Clave = vm.Clave,
                    Correo = vm.Correo,
                    Direccion = vm.Direccion,
                    Telefono = vm.Telefono,
                    RolId = vm.RolId,
                   HasError = false
                };
              return res;
           
           
        }
    }
}
