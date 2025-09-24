using Microsoft.EntityFrameworkCore;
using RecruitingApp.Models;

namespace RecruitingApp.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // Make sure schema exists
            await db.Database.MigrateAsync();

            // 1) Seed lookup tables -------------------------
            if (!await db.Industries.AnyAsync())
            {
                db.Industries.AddRange(
                    new Industry { Name = "Software", Description = "Software & SaaS" },
                    new Industry { Name = "Finance", Description = "Financial Services" }
                );
            }

            if (!await db.JobTitles.AnyAsync())
            {
                db.JobTitles.AddRange(
                    new JobTitle { Title = "Software Engineer", SalaryMin = 80000, SalaryMax = 160000 },
                    new JobTitle { Title = "Data Analyst", SalaryMin = 60000, SalaryMax = 120000 }
                );
            }

            // >>> CRITICAL: save lookups before you query them
            await db.SaveChangesAsync();

            // 2) Seed companies ------------------------------
            if (!await db.Companies.AnyAsync())
            {
                // Now these queries will succeed
                var software = await db.Industries.FirstAsync(i => i.Name == "Software");
                var finance = await db.Industries.FirstAsync(i => i.Name == "Finance");

                db.Companies.AddRange(
                    new Company { Name = "Contoso Ltd.", Industry = software, Website = "https://contoso.example", Email = "hr@contoso.example", Location = "500 Main St\nCincinnati, OH" },
                    new Company { Name = "Fabrikam Bank", Industry = finance, Website = "https://fabrikam.example", Email = "talent@fabrikam.example", Location = "1 Finance Way\nColumbus, OH" }
                );

                await db.SaveChangesAsync();
            }

            // 3) Seed candidates -----------------------------
            if (!await db.Candidates.AnyAsync())
            {
                var se = await db.JobTitles.FirstAsync(j => j.Title == "Software Engineer");
                var da = await db.JobTitles.FirstAsync(j => j.Title == "Data Analyst");
                var contoso = await db.Companies.FirstAsync(c => c.Name == "Contoso Ltd.");
                var fabrikam = await db.Companies.FirstAsync(c => c.Name == "Fabrikam Bank");

                db.Candidates.AddRange(
                    new Candidate { FirstName = "Alice", LastName = "Nguyen", Email = "alice@example.com", JobTitle = se, Company = contoso, Industry = contoso.Industry, SalaryExpectation = 120000, DateApplied = DateTime.UtcNow.Date.AddDays(-7), LinkedInUrl = "https://linkedin.com/in/alice" },
                    new Candidate { FirstName = "Bruno", LastName = "Singh", Email = "bruno@example.com", JobTitle = da, Company = fabrikam, Industry = fabrikam.Industry, SalaryExpectation = 85000, DateApplied = DateTime.UtcNow.Date.AddDays(-3) }
                );

                await db.SaveChangesAsync();
            }
        }
    }
}


