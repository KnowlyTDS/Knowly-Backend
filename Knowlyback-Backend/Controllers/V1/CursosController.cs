using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using KnowlyApp.Core.Application.Interfaces.Services;
using KnowlyApp.Core.Application.ViewModels.Cursos;
using EllipticCurve.Utils;
using Humanizer.Localisation;
using KnowlyApp.Core.Application.Services;
using KnowlyApp.Core.Domain.Entities;
using NuGet.Protocol.Core.Types;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using SendGrid.Helpers.Errors.Model;
using SendGrid.Helpers.Mail;

namespace KnowlyApp.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/cursos")]
    public class CursosController : ControllerBase
    {
        private readonly ICursosService _cursosService;

        public CursosController(ICursosService cursosService)
        {
            _cursosService = cursosService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveCursosViewModel cursoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
               await _cursosService.AddAsync(cursoViewModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al crear el curso: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            var cursos = await _cursosService.GetAllViewModel();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var curso = await _cursosService.GetByIdSaveViewModel(id);
            if (curso == null)
            {
                return NotFound($"Curso con ID {id} no encontrado.");
            }

            return Ok(curso);
        }

        // Endpoint para obtener la lista de estudiantes inscritos en un curso
        [HttpGet("{cursoId}/estudiantes")]
        public async Task<IActionResult> ObtenerEstudiantesInscritosEnCurso(int cursoId)
        {
            var estudiantesInscritos = await _cursosService.GetEstudiantesEnrolled(cursoId);
            return Ok(estudiantesInscritos);
        }


        // Endpoint para inscribir un estudiante en un curso
        [HttpPost("{cursoId}/estudiantes/{estudianteId}/inscribir")]
        public async Task<IActionResult> InscribirEstudianteEnCurso(int cursoId, int estudianteId)
        {
            await _cursosService.EnrollEstudianteInCourse(cursoId, estudianteId);
            return Ok();
        }

        // Endpoint para desinscribir un estudiante de un curso
        [HttpPost("{cursoId}/estudiantes/{estudianteId}/desinscribir")]
        public async Task<IActionResult> UnenrollEstudianteFromCurso(int cursoId, int estudianteId)
        {
            await _cursosService.UnenrollEstudianteFromCurso(cursoId, estudianteId);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveCursosViewModel cursoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _cursosService.UpdateAsync(cursoViewModel, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al actualizar el curso: {ex.Message}");
            }
        }
        [HttpDelete("{cursoId}")]
        public async Task<IActionResult> DeleteCurso(int cursoId)
        {
            try
            {
                await _cursosService.DeleteAsync(cursoId);
                return NoContent(); // Respuesta 204 No Content si la eliminación es exitosa
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Respuesta 404 Not Found si el curso no se encuentra
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno."); // Respuesta 500 Internal Server Error en caso de error
            }
        }

    }
}