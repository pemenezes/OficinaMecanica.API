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
    public class OrdemServicoController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public OrdemServicoController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            var list = await _ctx.OrdensServico
                .Include(o => o.Cliente)
                .Include(o => o.Funcionario)
                .AsNoTracking()
                .Select(o => new {
                    o.Id, o.ClienteId, ClienteNome = o.Cliente!.Nome,
                    o.FuncionarioId, Mecanico = o.Funcionario != null ? o.Funcionario.Nome : null,
                    o.Descricao, o.Concluida, o.DataAbertura, o.DataConclusao
                }).ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrdemServico>> GetById(int id)
        {
            var os = await _ctx.OrdensServico.FindAsync(id);
            return os is null ? NotFound() : Ok(os);
        }

        [HttpPost]
        public async Task<ActionResult> Post(OrdemServico os)
        {
            os.Id = 0;
            os.Concluida = false;
            os.DataAbertura = DateTime.Now;
            os.DataConclusao = null;

            _ctx.OrdensServico.Add(os);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = os.Id }, os);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, OrdemServico os)
        {
            if (id != os.Id) return BadRequest();

            var atual = await _ctx.OrdensServico.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (atual is null) return NotFound();

            if (atual.Concluida)
                return Conflict("OS concluída não pode ser editada.");

            // permitir concluir agora
            if (!atual.Concluida && os.Concluida)
                os.DataConclusao = DateTime.Now;

            _ctx.Entry(os).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var os = await _ctx.OrdensServico.FindAsync(id);
            if (os is null) return NotFound();
            if (os.Concluida) return Conflict("OS concluída não pode ser excluída.");
            _ctx.OrdensServico.Remove(os);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
