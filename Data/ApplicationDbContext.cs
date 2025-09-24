using Microsoft.EntityFrameworkCore;
using RecruitingApp.Models;

namespace RecruitingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<JobTitle> JobTitles => Set<JobTitle>();
        public DbSet<Industry> Industries => Set<Industry>();
    }
}

