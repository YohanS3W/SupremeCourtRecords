using System.Collections.Generic;

namespace SupremeCourtRecords.Models
{
    public class Judge
    {
        public int JudgeId { get; set; }
        public string? Name { get; set; }

        public List<Case>? Cases { get; set; }
    }
}