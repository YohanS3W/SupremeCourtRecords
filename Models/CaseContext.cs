using Microsoft.EntityFrameworkCore;

namespace SupremeCourtRecords.Models
{
    public class CaseContext : DbContext
    {
        public CaseContext(DbContextOptions<CaseContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Petitioner> Petitioners { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Case> Cases { get; set; }
    }
}