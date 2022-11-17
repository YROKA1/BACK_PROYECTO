using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RADER.Models;

namespace RADER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugerenciumsController : ControllerBase
    {
        private readonly RADERContext _context;

        public SugerenciumsController(RADERContext context)
        {
            _context = context;
        }

        // GET: api/Sugerenciums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sugerencium>>> GetSugerencia()
        {
            return await _context.Sugerencia.ToListAsync();
        }

        // GET: api/Sugerenciums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sugerencium>> GetSugerencium(int id)
        {
            var sugerencium = await _context.Sugerencia.FindAsync(id);

            if (sugerencium == null)
            {
                return NotFound();
            }

            return sugerencium;
        }

        // PUT: api/Sugerenciums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSugerencium(int id, Sugerencium sugerencium)
        {
            if (id != sugerencium.IdSugerencia)
            {
                return BadRequest();
            }

            _context.Entry(sugerencium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SugerenciumExists(id))
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

        // POST: api/Sugerenciums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sugerencium>> PostSugerencium(Sugerencium sugerencium)
        {
            _context.Sugerencia.Add(sugerencium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSugerencium", new { id = sugerencium.IdSugerencia }, sugerencium);
        }

        // DELETE: api/Sugerenciums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSugerencium(int id)
        {
            var sugerencium = await _context.Sugerencia.FindAsync(id);
            if (sugerencium == null)
            {
                return NotFound();
            }

            _context.Sugerencia.Remove(sugerencium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SugerenciumExists(int id)
        {
            return _context.Sugerencia.Any(e => e.IdSugerencia == id);
        }
    }
}
