using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SupremeCourtRecords.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public List<Case>? Cases { get; set; }
    }
}