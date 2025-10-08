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
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public AgendamentoController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
            var list = await _ctx.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Funcionario)
                .AsNoTracking()
                .Select(a => new {
                    a.Id, a.ClienteId, ClienteNome = a.Cliente!.Nome,
                    a.FuncionarioId, Mecanico = a.Funcionario!.Nome,
                    a.DataHora, a.Servico
                }).ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Agendamento>> GetById(int id)
        {
            var ag = await _ctx.Agendamentos.FindAsync(id);
            return ag is null ? NotFound() : Ok(ag);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Agendamento ag)
        {
            if (await TemChoque(ag.FuncionarioId, ag.DataHora))
                return Conflict("Choque de horário para este mecânico.");

            _ctx.Agendamentos.Add(ag);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = ag.Id }, ag);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Agendamento ag)
        {
            if (id != ag.Id) return BadRequest();

            if (await TemChoque(ag.FuncionarioId, ag.DataHora, ag.Id))
                return Conflict("Choque de horário para este mecânico.");

            _ctx.Entry(ag).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ag = await _ctx.Agendamentos.FindAsync(id);
            if (ag is null) return NotFound();
            _ctx.Agendamentos.Remove(ag);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        private async Task<bool> TemChoque(int funcionarioId, DateTime dataHora, int? ignorarId = null)
        {
            var inicio = dataHora.AddMinutes(-59);
            var fim = dataHora.AddMinutes(59);

            var q = _ctx.Agendamentos.AsQueryable()
                .Where(a => a.FuncionarioId == funcionarioId && a.DataHora >= inicio && a.DataHora <= fim);

            if (ignorarId.HasValue) q = q.Where(a => a.Id != ignorarId.Value);

            return await q.AnyAsync();
        }
    }
}
