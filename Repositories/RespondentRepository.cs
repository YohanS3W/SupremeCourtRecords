using SupremeCourtRecords.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupremeCourtRecords.Repositories
{
    public class RespondentRepository
    {
        private readonly CaseContext _context;

        public RespondentRepository(CaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Respondent>> GetAllAsync() => await _context.Respondents.ToListAsync();

        public async Task<Respondent> GetByIdAsync(int id) => await _context.Respondents.FindAsync(id);

        public async Task AddAsync(Respondent respondent)
        {
            _context.Respondents.Add(respondent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Respondent respondent)
        {
            _context.Entry(respondent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var respondent = await _context.Respondents.FindAsync(id);
            if (respondent != null)
            {
                _context.Respondents.Remove(respondent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
