using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SupremeCourtRecords.Models
{
    public class CaseContext : IdentityDbContext<IdentityUser>
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