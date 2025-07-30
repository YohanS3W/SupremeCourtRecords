//code
namespace SupremeCourtRecords.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public int CategoryId { get; set; }
        public int PetitionerId { get; set; }
        public int RespondentId { get; set; }
        public int JudgeId { get; set; }

        public Category? Category { get; set; }
        public Petitioner? Petitioner { get; set; }
        public Respondent? Respondent { get; set; }
        public Judge? Judge { get; set; }
    }
}