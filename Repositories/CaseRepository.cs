using SupremeCourtRecords.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupremeCourtRecords.Repositories
{
    public class CaseRepository
    {
        private readonly CaseContext _context;

        public CaseRepository(CaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Case>> GetAllAsync() => await _context.Cases.ToListAsync();

        public async Task<Case> GetByIdAsync(int id) => await _context.Cases.FindAsync(id);

        public async Task AddAsync(Case case1)
        {
            _context.Cases.Add(case1);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Case case1)
        {
            _context.Entry(case1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var case1 = await _context.Cases.FindAsync(id);
            if (case1 != null)
            {
                _context.Cases.Remove(case1);
                await _context.SaveChangesAsync();
            }
        }
    }
}
