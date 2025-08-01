using System.ComponentModel.DataAnnotations;

namespace SupremeCourtRecords.Models
{
    public class JudgeDTO
    {
        public int JudgeId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}
