using System.Collections.Generic;

namespace SupremeCourtRecords.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        public List<Case>? Cases { get; set; }
    }
}