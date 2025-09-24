using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Candidates
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context) => _context = context;

        public Candidate Candidate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Candidate = await _context.Candidates
                .Include(c => c.JobTitle)
                .Include(c => c.Industry)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.CandidateId == id);

            if (Candidate == null) return NotFound();

            return Page();
        }
    }
}

