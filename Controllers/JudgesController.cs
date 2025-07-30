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
    public class JudgesController : ControllerBase
    {
        private readonly CaseContext _context;

        public JudgesController(CaseContext context)
        {
            _context = context;
        }

        // GET: api/Judges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Judge>>> GetJudges()
        {
            return await _context.Judges.ToListAsync();
        }

        // GET: api/Judges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Judge>> GetJudge(int id)
        {
            var judge = await _context.Judges.FindAsync(id);

            if (judge == null)
            {
                return NotFound();
            }

            return judge;
        }

        // PUT: api/Judges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJudge(int id, Judge judge)
        {
            if (id != judge.JudgeId)
            {
                return BadRequest();
            }

            _context.Entry(judge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JudgeExists(id))
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

        // POST: api/Judges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Judge>> PostJudge(Judge judge)
        {
            _context.Judges.Add(judge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJudge", new { id = judge.JudgeId }, judge);
        }

        // DELETE: api/Judges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudge(int id)
        {
            var judge = await _context.Judges.FindAsync(id);
            if (judge == null)
            {
                return NotFound();
            }

            _context.Judges.Remove(judge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JudgeExists(int id)
        {
            return _context.Judges.Any(e => e.JudgeId == id);
        }
    }
}
