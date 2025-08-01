using SupremeCourtRecords.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

public class JudgeService : IJudgeService
{
    private readonly CaseContext _context;

    public JudgeService(CaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Judge>> GetAllJudgesAsync()
    {
        return await _context.Judges.ToListAsync();
    }

    public async Task<Judge> GetJudgeByIdAsync(int id)
    {
        return await _context.Judges.FindAsync(id);
    }

    public async Task AddJudgeAsync(Judge judge)
    {
        _context.Judges.Add(judge);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateJudgeAsync(int id, Judge judge)
    {
        _context.Entry(judge).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteJudgeAsync(int id)
    {
        var judge = await _context.Judges.FindAsync(id);
        if (judge != null)
        {
            _context.Judges.Remove(judge);
            await _context.SaveChangesAsync();
        }
    }
}
