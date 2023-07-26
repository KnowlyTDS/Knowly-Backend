using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace Knowlyback_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Manejo de sesion")]
    public class AccountController
    {
        [HttpPost("Authenticate")]

        public async Task<IActionResult>AuthenticateAsync(request)



    }
}
