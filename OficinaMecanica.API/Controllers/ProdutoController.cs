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
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public ProdutoController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get() =>
            Ok(await _ctx.Produtos.AsNoTracking().ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            var p = await _ctx.Produtos.FindAsync(id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Produto p)
        {
            _ctx.Produtos.Add(p);
            await _ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = p.Id }, p);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Produto p)
        {
            if (id != p.Id) return BadRequest();
            _ctx.Entry(p).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _ctx.Produtos.FindAsync(id);
            if (p is null) return NotFound();
            _ctx.Produtos.Remove(p);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
