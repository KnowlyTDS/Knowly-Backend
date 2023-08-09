using KnowlyApp.core.Domain.Entities;
using KnowlyApp.Core.Application.Dtos.Account;
using KnowlyApp.Core.Application.Dtos.User;
using KnowlyApp.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Knowlyback_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Manejo de sesion")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iuserService;

        public UserController(IUserService UserService)
        {
            _iuserService = UserService;
        }

        [HttpPost("Loggin")]
        [Consumes(MediaTypeNames.Application.Json)] //COLOCAR EN LOS POST Y PUT
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Loggin",
            Description = "Correo y contraseña para generar el token y acceder segun su rol."
            )]
        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            try
            {
                var user = await _iuserService.LoginAsync(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
            
        }


        [HttpPost("Register")]
        [Consumes(MediaTypeNames.Application.Json)] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Registro",
            Description = "Datos generales para la creacion de un usuario."
            )]
        public async Task<IActionResult> Register([FromBody]CreateUserRequest vm)
        {
            try
            {
                var ress = await _iuserService.RegisterAsync(vm);
                return Ok(ress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }           

            
        }


    }
}
