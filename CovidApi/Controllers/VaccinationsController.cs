using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidApi.Data;
using CovidApi.Models;

namespace CovidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly VaccinationContext _context;

        public VaccinationsController(VaccinationContext context)
        {
            _context = context;
        }

        // GET: api/Vaccinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccination>>> GetVaccination()
        {
            return await _context.Vaccination.ToListAsync();
        }

        // GET: api/Vaccinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccination>> GetVaccination(int id)
        {
            var vaccination = await _context.Vaccination.FindAsync(id);

            if (vaccination == null)
            {
                return NotFound();
            }

            return vaccination;
        }

        // PUT: api/Vaccinations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccination(int id, Vaccination vaccination)
        {
            if (id != vaccination.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinationExists(id))
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

        // POST: api/Vaccinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaccination>> PostVaccination(Vaccination vaccination)
        {
            _context.Vaccination.Add(vaccination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccination", new { id = vaccination.Id }, vaccination);
        }

        // DELETE: api/Vaccinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccination(int id)
        {
            var vaccination = await _context.Vaccination.FindAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }

            _context.Vaccination.Remove(vaccination);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccinationExists(int id)
        {
            return _context.Vaccination.Any(e => e.Id == id);
        }
    }
}
