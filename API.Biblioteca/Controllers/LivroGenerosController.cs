using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Biblioteca.Data;
using API.Biblioteca.Models;

namespace API.Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroGenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LivroGenerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LivroGeneros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroGenero>>> GetLivroGenero()
        {
            return await _context.LivroGenero.ToListAsync();
        }

        // GET: api/LivroGeneros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LivroGenero>> GetLivroGenero(Guid id)
        {
            var livroGenero = await _context.LivroGenero.FindAsync(id);

            if (livroGenero == null)
            {
                return NotFound();
            }

            return livroGenero;
        }

        // PUT: api/LivroGeneros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivroGenero(Guid id, LivroGenero livroGenero)
        {
            if (id != livroGenero.LivroGeneroId)
            {
                return BadRequest();
            }

            _context.Entry(livroGenero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroGeneroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LivroGeneros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LivroGenero>> PostLivroGenero(LivroGenero livroGenero)
        {
            _context.LivroGenero.Add(livroGenero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivroGenero", new { id = livroGenero.LivroGeneroId }, livroGenero);
        }

        // DELETE: api/LivroGeneros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivroGenero(Guid id)
        {
            var livroGenero = await _context.LivroGenero.FindAsync(id);
            if (livroGenero == null)
            {
                return NotFound();
            }

            _context.LivroGenero.Remove(livroGenero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroGeneroExists(Guid id)
        {
            return _context.LivroGenero.Any(e => e.LivroGeneroId == id);
        }
    }
}
