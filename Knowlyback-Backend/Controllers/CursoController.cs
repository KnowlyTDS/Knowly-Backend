using KnowlyApp.Core.Application.Dtos.Cursos;
using KnowlyApp.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Knowlyback_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Controlador de Cursos")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _icursoService;

        public CursoController(ICursoService icursoService)
        {
            _icursoService = icursoService;
        }

        [HttpPost("Register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
       Summary = "Registro",
       Description = "Datos generales para la creacion de un curso."
       )]
        public async Task<IActionResult> Register([FromBody] CreateCursoRequest vm)
        {
            try
            {
                var ress = await _icursoService.RegisterAsync(vm);
                return Ok(ress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }


        }
    }
}
