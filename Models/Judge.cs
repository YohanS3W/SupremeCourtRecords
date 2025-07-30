using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SupremeCourtRecords.Models
{
    public class Judge
    {
        public int JudgeId { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public List<Case>? Cases { get; set; }
    }
}