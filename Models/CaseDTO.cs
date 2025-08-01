using System.ComponentModel.DataAnnotations;

namespace SupremeCourtRecords.Models
{
    public class CaseDTO
    {
        public int CaseId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int PetitionerId { get; set; }

        [Required]
        public int RespondentId { get; set; }

        [Required]
        public int JudgeId { get; set; }
    }
}
