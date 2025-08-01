using SupremeCourtRecords.Models;

public interface ICaseService
{
    Task<IEnumerable<Case>> GetAllCasesAsync();
    Task<Case> GetCaseByIdAsync(int id);
    Task AddCaseAsync(Case case1);
    Task UpdateCaseAsync(int id, Case case1);
    Task DeleteCaseAsync(int id);
}
