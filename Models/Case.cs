using System.Text.Json.Serialization;

namespace SupremeCourtRecords.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public int CategoryId { get; set; }
        public int PetitionerId { get; set; }
        public int RespondentId { get; set; }
        public int JudgeId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
        [JsonIgnore]
        public Petitioner? Petitioner { get; set; }
        [JsonIgnore]
        public Respondent? Respondent { get; set; }
        [JsonIgnore]
        public Judge? Judge { get; set; }
    }
}