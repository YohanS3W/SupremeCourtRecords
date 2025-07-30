using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupremeCourtRecords.Models;

namespace SupremeCourtRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetitionersController : ControllerBase
    {
        private readonly CaseContext _context;

        public PetitionersController(CaseContext context)
        {
            _context = context;
        }

        // GET: api/Petitioners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Petitioner>>> GetPetitioners()
        {
            return await _context.Petitioners.ToListAsync();
        }

        // GET: api/Petitioners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Petitioner>> GetPetitioner(int id)
        {
            var petitioner = await _context.Petitioners.FindAsync(id);

            if (petitioner == null)
            {
                return NotFound();
            }

            return petitioner;
        }

        // PUT: api/Petitioners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetitioner(int id, Petitioner petitioner)
        {
            if (id != petitioner.PetitionerId)
            {
                return BadRequest();
            }

            _context.Entry(petitioner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetitionerExists(id))
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

        // POST: api/Petitioners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Petitioner>> PostPetitioner(Petitioner petitioner)
        {
            _context.Petitioners.Add(petitioner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetitioner", new { id = petitioner.PetitionerId }, petitioner);
        }

        // DELETE: api/Petitioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetitioner(int id)
        {
            var petitioner = await _context.Petitioners.FindAsync(id);
            if (petitioner == null)
            {
                return NotFound();
            }

            _context.Petitioners.Remove(petitioner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetitionerExists(int id)
        {
            return _context.Petitioners.Any(e => e.PetitionerId == id);
        }
    }
}
