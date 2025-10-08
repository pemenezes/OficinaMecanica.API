using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaMecanica.API.Auth;
using OficinaMecanica.API.Data;
using OficinaMecanica.API.Dtos;

namespace OficinaMecanica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private readonly IConfiguration _cfg;
        public AuthController(AppDbContext ctx, IConfiguration cfg) { _ctx = ctx; _cfg = cfg; }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> Login([FromBody] UsuarioLoginDto dto)
        {
            var user = await _ctx.Usuarios.FirstOrDefaultAsync(u => u.Login == dto.Login && u.Senha == dto.Senha);
            if (user == null) return Unauthorized();

            var token = JwtTokenGenerator.GenerateToken(user, _cfg);
            return Ok(new LoginResultDto { Token = token, Nome = user.Nome, Perfil = user.Perfil });
        }
    }
}
