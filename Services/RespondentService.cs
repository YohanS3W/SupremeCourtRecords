using SupremeCourtRecords.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

public class RespondentService : IRespondentService
{
    private readonly CaseContext _context;

    public RespondentService(CaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Respondent>> GetAllRespondentsAsync()
    {
        return await _context.Respondents.ToListAsync();
    }

    public async Task<Respondent> GetRespondentByIdAsync(int id)
    {
        return await _context.Respondents.FindAsync(id);
    }

    public async Task AddRespondentAsync(Respondent respondent)
    {
        _context.Respondents.Add(respondent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRespondentAsync(int id, Respondent respondent)
    {
        _context.Entry(respondent).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRespondentAsync(int id)
    {
        var respondent = await _context.Respondents.FindAsync(id);
        if (respondent != null)
        {
            _context.Respondents.Remove(respondent);
            await _context.SaveChangesAsync();
        }
    }
}
