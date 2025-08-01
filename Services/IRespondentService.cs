using SupremeCourtRecords.Models;

public interface IRespondentService
{
    Task<IEnumerable<Respondent>> GetAllRespondentsAsync();
    Task<Respondent> GetRespondentByIdAsync(int id);
    Task AddRespondentAsync(Respondent respondent);
    Task UpdateRespondentAsync(int id, Respondent respondent);
    Task DeleteRespondentAsync(int id);
}
