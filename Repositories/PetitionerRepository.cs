using SupremeCourtRecords.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupremeCourtRecords.Repositories
{
    public class PetitionerRepository
    {
        private readonly CaseContext _context;

        public PetitionerRepository(CaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Petitioner>> GetAllAsync() => await _context.Petitioners.ToListAsync();

        public async Task<Petitioner> GetByIdAsync(int id) => await _context.Petitioners.FindAsync(id);

        public async Task AddAsync(Petitioner petitioner)
        {
            _context.Petitioners.Add(petitioner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Petitioner petitioner)
        {
            _context.Entry(petitioner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var petitioner = await _context.Petitioners.FindAsync(id);
            if (petitioner != null)
            {
                _context.Petitioners.Remove(petitioner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
