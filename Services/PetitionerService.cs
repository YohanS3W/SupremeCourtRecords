using SupremeCourtRecords.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

public class PetitionerService : IPetitionerService
{
    private readonly CaseContext _context;

    public PetitionerService(CaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Petitioner>> GetAllPetitionersAsync()
    {
        return await _context.Petitioners.ToListAsync();
    }

    public async Task<Petitioner> GetPetitionerByIdAsync(int id)
    {
        return await _context.Petitioners.FindAsync(id);
    }

    public async Task AddPetitionerAsync(Petitioner petitioner)
    {
        _context.Petitioners.Add(petitioner);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePetitionerAsync(int id, Petitioner petitioner)
    {
        _context.Entry(petitioner).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePetitionerAsync(int id)
    {
        var petitioner = await _context.Petitioners.FindAsync(id);
        if (petitioner != null)
        {
            _context.Petitioners.Remove(petitioner);
            await _context.SaveChangesAsync();
        }
    }
}
