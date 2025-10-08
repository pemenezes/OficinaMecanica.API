using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaMecanica.API.Data;
using OficinaMecanica.API.Models;

namespace OficinaMecanica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public FuncionarioController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> Get([FromQuery] string? funcao = null)
        {
            var q = _ctx.Funcionarios.AsQueryable().Where(f => f.Ativo);
            if (!string.IsNullOrEmpty(funcao)) q = q.Where(f => f.Funcao == funcao);
            return Ok(await q.AsNoTracking().ToListAsync());
        }
    }
}
