using SupremeCourtRecords.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupremeCourtRecords.Repositories
{
    public class JudgeRepository
    {
        private readonly CaseContext _context;

        public JudgeRepository(CaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Judge>> GetAllAsync() => await _context.Judges.ToListAsync();

        public async Task<Judge> GetByIdAsync(int id) => await _context.Judges.FindAsync(id);

        public async Task AddAsync(Judge judge)
        {
            _context.Judges.Add(judge);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Judge judge)
        {
            _context.Entry(judge).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var judge = await _context.Judges.FindAsync(id);
            if (judge != null)
            {
                _context.Judges.Remove(judge);
                await _context.SaveChangesAsync();
            }
        }
    }
}
