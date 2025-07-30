using System.Collections.Generic;

namespace SupremeCourtRecords.Models
{
    public class Petitioner
    {
        public int PetitionerId { get; set; }
        public string? Name { get; set; }

        public List<Case>? Cases { get; set; }
    }
}