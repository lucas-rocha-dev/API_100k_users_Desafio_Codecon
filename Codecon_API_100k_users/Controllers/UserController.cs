using Codecon_API_100k_users.Data;
using Codecon_API_100k_users.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Codecon_API_100k_users.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService service = new UserServices();
        private readonly UsuarioMemoryService _usuarioService;

        public UserController(UsuarioMemoryService usuarioMemoryService) 
        {
            _usuarioService = usuarioMemoryService;

        }

        [HttpPost("UserPost")]
        [RequestSizeLimit(70 * 1024 * 1024)] // 70 MB

        public IActionResult UserPost(List<User> user)
        {
            var stopwatch = Stopwatch.StartNew();

            service = new UserServices();
            var usuarios = service.PostUsers(user);
            _usuarioService.Usuarios = usuarios;

            stopwatch.Stop();
            var tempoMs = stopwatch.ElapsedMilliseconds;

            return Ok(user.Count + "tudo isso de usuarios " + tempoMs);
        }

        [HttpGet("TopCountries")] 
        public IActionResult TopCountries() {
            var stopwatch = Stopwatch.StartNew();


            service = new UserServices();
            var paises = service.TopCountries(_usuarioService.Usuarios);

            stopwatch.Stop();
            var tempoMs = stopwatch.ElapsedMilliseconds;

            return Ok(new {
                paises,
                tempoMs 
            });
        }
    }
}
