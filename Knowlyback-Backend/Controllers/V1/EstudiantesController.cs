using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Estudiantes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knowlyback_Backend.Controllers.V1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class EstudiantesController : BaseApiController
    {
        private readonly IEstudiantesService _estudiantesService;

        public EstudiantesController(IEstudiantesService estudiantesService)
        {
            _estudiantesService = estudiantesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EstudiantesViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var estudiantes = await _estudiantesService.GetAllViewModel();

                if (estudiantes == null || estudiantes.Count == 0)
                {
                    return NotFound(":( Lo siento no existen estudiantes");
                }

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveEstudianteViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var estudiantes = await _estudiantesService.GetByIdSaveViewModel(id);

                if (estudiantes == null)
                {
                    return NotFound(":( Lo siento no existe el estudiantes");
                }

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(SaveEstudianteViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                SaveEstudianteViewModel saveEstudianteView = new()
                {
                    Tel = vm.Tel,
                    Nombre = vm.Nombre,
                    Apellido = vm.Apellido,
                    Foto = vm.Foto,
                    Genero = vm.Genero,
                    Email = vm.Email,
                    isActive = vm.isActive,
                    CantidadTareas = vm.CantidadTareas
                };

                await _estudiantesService.AddAsync(saveEstudianteView);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveEstudianteViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(SaveEstudianteViewModel vm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                SaveEstudianteViewModel existingEstudiante = new()
                {
                    // Actualizar las propiedades relevantes

                    Nombre = vm.Nombre,
                    Apellido = vm.Apellido,
                    Tel = vm.Tel,
                    Foto = vm.Foto,
                    Genero = vm.Genero,
                    Email = vm.Email,
                    isActive = vm.isActive,
                    CantidadTareas = vm.CantidadTareas,
                    CantidadCursos = vm.CantidadCursos,
                    CantidadEntregas = vm.CantidadEntregas
                };

                await _estudiantesService.UpdateAsync(existingEstudiante, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _estudiantesService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("curso/{cursoId}")]
        public async Task<IActionResult> GetEstudiantesByCurso(int cursoId)
        {
            try
            {
                var estudiantes = await _estudiantesService.GetEstudiantesByCurso(cursoId);
                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}