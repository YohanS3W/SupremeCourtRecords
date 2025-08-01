using SupremeCourtRecords.Models;

public interface IPetitionerService
{
    Task<IEnumerable<Petitioner>> GetAllPetitionersAsync();
    Task<Petitioner> GetPetitionerByIdAsync(int id);
    Task AddPetitionerAsync(Petitioner petitioner);
    Task UpdatePetitionerAsync(int id, Petitioner petitioner);
    Task DeletePetitionerAsync(int id);
}
