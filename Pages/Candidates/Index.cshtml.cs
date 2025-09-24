using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Candidates
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;

        public IList<Candidate> Candidate { get; set; } = new List<Candidate>();

        public async Task OnGetAsync()
        {
            Candidate = await _context.Candidates
                .Include(c => c.JobTitle)
                .Include(c => c.Industry)
                .Include(c => c.Company)
                .OrderBy(c => c.LastName).ThenBy(c => c.FirstName)
                .ToListAsync();
        }
    }
}

