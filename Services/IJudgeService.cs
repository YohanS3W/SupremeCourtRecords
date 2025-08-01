using SupremeCourtRecords.Models;

public interface IJudgeService
{
    Task<IEnumerable<Judge>> GetAllJudgesAsync();
    Task<Judge> GetJudgeByIdAsync(int id);
    Task AddJudgeAsync(Judge judge);
    Task UpdateJudgeAsync(int id, Judge judge);
    Task DeleteJudgeAsync(int id);
}
