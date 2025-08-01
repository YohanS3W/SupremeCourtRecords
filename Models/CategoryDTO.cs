using System.ComponentModel.DataAnnotations;

namespace SupremeCourtRecords.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Name { get; set; }
    }
}