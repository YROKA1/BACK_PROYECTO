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
    public class AlertumsController : ControllerBase
    {
        private readonly RADERContext _context;

        public AlertumsController(RADERContext context)
        {
            _context = context;
        }

        // GET: api/Alertums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alertum>>> GetAlerta()
        {
            return await _context.Alerta.ToListAsync();
        }

        // GET: api/Alertums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alertum>> GetAlertum(int id)
        {
            var alertum = await _context.Alerta.FindAsync(id);

            if (alertum == null)
            {
                return NotFound();
            }

            return alertum;
        }

        // PUT: api/Alertums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertum(int id, Alertum alertum)
        {
            if (id != alertum.IdAlerta)
            {
                return BadRequest();
            }

            _context.Entry(alertum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertumExists(id))
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

        // POST: api/Alertums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alertum>> PostAlertum(Alertum alertum)
        {
            _context.Alerta.Add(alertum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertum", new { id = alertum.IdAlerta }, alertum);
        }

        // DELETE: api/Alertums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertum(int id)
        {
            var alertum = await _context.Alerta.FindAsync(id);
            if (alertum == null)
            {
                return NotFound();
            }

            _context.Alerta.Remove(alertum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertumExists(int id)
        {
            return _context.Alerta.Any(e => e.IdAlerta == id);
        }
    }
}
