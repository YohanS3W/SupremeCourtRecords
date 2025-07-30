using System.Collections.Generic;

namespace SupremeCourtRecords.Models
{
    public class Respondent
    {
        public int RespondentId { get; set; }
        public string? Name { get; set; }

        public List<Case>? Cases { get; set; }
    }
}