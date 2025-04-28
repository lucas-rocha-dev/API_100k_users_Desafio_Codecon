using Codecon_API_100k_users.Data;
using Codecon_API_100k_users.Dto;
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

        public ActionResult UserPost(List<User> user)
        {
            var stopwatch = Stopwatch.StartNew();

            service = new UserServices();
            var usuarios = service.PostUsers(user);
            _usuarioService.Usuarios = usuarios;

            stopwatch.Stop();
            var tempoMs = stopwatch.ElapsedMilliseconds;

            return Ok(user.Count + " foram registrado com sucesso! " + tempoMs);
        }

        [HttpGet("TopCountries")] 
        public ActionResult<UserResponse<List<TopCountriesDto>>> TopCountries() {
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

        [HttpGet("SuperUsers")]
        public ActionResult<List<User>> SuperUsers()
        {
            var stopwatch = Stopwatch.StartNew();
            var superUsers = service.SuperUsers(_usuarioService.Usuarios);
            stopwatch.Stop();
            var tempoMs = stopwatch.ElapsedMilliseconds;
            return Ok(new {
                superUsers,
                tempoMs
            });
        }

        [HttpGet("TeamInsights")]
        public ActionResult<List<TeamInsightsDto>> TeamInsights()
        {
            var stopwatch = Stopwatch.StartNew();
            var times = service.TeamInsights(_usuarioService.Usuarios);
            stopwatch.Stop();
            var tempoMs = stopwatch.ElapsedMilliseconds;
            return Ok(new {
                times,
                tempoMs
            });
        }

        [HttpGet("ActiveUsersPerDay")]
        public ActionResult<List<ActivePerDayDto>> ActiveUsersPerDay(int minQtdLogin = 0)
        {
            var stopwatch = Stopwatch.StartNew();
            var activeUsers = service.ActiveUsersPerDay(_usuarioService.Usuarios, minQtdLogin);
            stopwatch.Stop();
            var tempoMs = stopwatch.ElapsedMilliseconds;
            return Ok(new {
                activeUsers,
                tempoMs
            });
        }
    }
}
