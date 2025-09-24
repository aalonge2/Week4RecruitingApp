using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) => _context = context;

        public Company Company { get; set; } = default!;
        public IList<Candidate> Candidates { get; set; } = new List<Candidate>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Company = await _context.Companies
                .Include(c => c.Industry)
                .FirstOrDefaultAsync(m => m.CompanyId == id);

            if (Company == null) return NotFound();

            Candidates = await _context.Candidates
                .Include(c => c.JobTitle)
                .Where(c => c.CompanyId == Company.CompanyId)
                .OrderBy(c => c.LastName).ThenBy(c => c.FirstName)
                .ToListAsync();

            return Page();
        }
    }
}

