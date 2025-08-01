using System.ComponentModel.DataAnnotations;

namespace SupremeCourtRecords.Models
{
    public class RespondentDTO
    {
        public int RespondentId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}
