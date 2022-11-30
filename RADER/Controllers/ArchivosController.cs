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
    public class ArchivosController : ControllerBase
    {
        private readonly RADERContext _context;

        public ArchivosController(RADERContext context)
        {
            _context = context;
        }

        // GET: api/Archivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivos>>> GetArchivos()
        {
            return await _context.Archivos.ToListAsync();
        }

        // GET: api/Archivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivos>> GetArchivos(int id)
        {
            var archivos = await _context.Archivos.FindAsync(id);

            if (archivos == null)
            {
                return NotFound();
            }

            return archivos;
        }

        // PUT: api/Archivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivos(int id, Archivos archivos)
        {
            if (id != archivos.IdArchivo)
            {
                return BadRequest();
            }

            _context.Entry(archivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivosExists(id))
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

       
        // DELETE: api/Archivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivos(int id)
        {
            var archivos = await _context.Archivos.FindAsync(id);
            if (archivos == null)
            {
                return NotFound();
            }

            _context.Archivos.Remove(archivos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public ActionResult PostArchivos([FromForm] List<IFormFile> files)
        {
            List<Archivos> archivos = new List<Archivos>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var filepatch = "C:\\Users\\Nicolas\\Desktop\\SergioUwU\\Back Sergio\\RADER\\RADER\\Uploads\\";
                      // fs =new FileStream(, FileMode.Open, FileAccess.ReadWrite
                        
                        double tam = file.Length;
                        tam = tam / 1000000;
                        tam = Math.Round(tam, 2);
                        Archivos archivo = new Archivos();
                        archivo.ExtensionArchivo = Path.GetExtension(file.FileName).Substring(1);
                        archivo.NombreArchivo = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.CapacidadArchivo = (float?)tam;
                        filepatch = filepatch + archivo.NombreArchivo + "." + archivo.ExtensionArchivo;
                        archivo.UbicacionArchivo = filepatch;
                        using (var stream = System.IO.File.Create(filepatch))
                        {
                            file.CopyToAsync(stream);
                        }
                        archivos.Add(archivo);
                    }
                    _context.Archivos.AddRange(archivos);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(archivos);
        }
        private bool ArchivosExists(int id)
        {
            return _context.Archivos.Any(e => e.IdArchivo == id);
        }
    }
}
