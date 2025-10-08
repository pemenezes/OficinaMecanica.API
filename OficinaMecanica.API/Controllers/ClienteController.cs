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
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public ClienteController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get() =>
            Ok(await _ctx.Clientes.AsNoTracking().ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var c = await _ctx.Clientes.FindAsync(id);
            return c is null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente c)
        {
            _ctx.Clientes.Add(c);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = c.Id }, c);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Cliente c)
        {
            if (id != c.Id) return BadRequest();
            _ctx.Entry(c).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var c = await _ctx.Clientes.FindAsync(id);
            if (c is null) return NotFound();
            _ctx.Clientes.Remove(c);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}

