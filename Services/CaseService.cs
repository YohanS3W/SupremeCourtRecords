
using SupremeCourtRecords.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

public class CaseService : ICaseService
{
    private readonly CaseContext _context;

    public CaseService(CaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Case>> GetAllCasesAsync()
    {
        return await _context.Cases.ToListAsync();
    }

    public async Task<Case> GetCaseByIdAsync(int id)
    {
        return await _context.Cases.FindAsync(id);
    }




    public async Task AddCaseAsync(Case case1)
    {
        _context.Cases.Add(case1);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCaseAsync(int id, Case case1)
    {
        _context.Entry(case1).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCaseAsync(int id)
    {
        var case1 = await _context.Cases.FindAsync(id);
        if (case1 != null)
        {
            _context.Cases.Remove(case1);
            await _context.SaveChangesAsync();
        }
    }
}