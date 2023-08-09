using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(IUserRepository iuserRepository, IMapper mapper)
        {
            _iuserRepository = iuserRepository;
            _mapper = mapper;

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
            Usuario entity = _mapper.Map<Usuario>(vm);
            entity = await _iuserRepository.AddAsync(entity);
            CreateUserResponse svm = _mapper.Map<CreateUserResponse>(entity);
            return svm;
        }
    }
}
