using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        public SelectList JobTitleOptions { get; set; } = default!;
        public SelectList IndustryOptions { get; set; } = default!;
        public SelectList CompanyOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Candidate = await _context.Candidates
                .Include(c => c.JobTitle)
                .Include(c => c.Industry)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.CandidateId == id);

            if (Candidate == null) return NotFound();

            await LoadLookupsAsync(Candidate.JobTitleId, Candidate.IndustryId, Candidate.CompanyId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync(Candidate.JobTitleId, Candidate.IndustryId, Candidate.CompanyId);
                return Page();
            }

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Candidates.Any(e => e.CandidateId == Candidate.CandidateId))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadLookupsAsync(int? selectedJobTitleId, int? selectedIndustryId, int? selectedCompanyId)
        {
            var jobTitles = await _context.JobTitles.OrderBy(j => j.Title).ToListAsync();
            var industries = await _context.Industries.OrderBy(i => i.Name).ToListAsync();
            var companies = await _context.Companies.OrderBy(c => c.Name).ToListAsync();

            JobTitleOptions = new SelectList(jobTitles, nameof(JobTitle.JobTitleId), nameof(JobTitle.Title), selectedJobTitleId);
            IndustryOptions = new SelectList(industries, nameof(Industry.IndustryId), nameof(Industry.Name), selectedIndustryId);
            CompanyOptions = new SelectList(companies, nameof(Company.CompanyId), nameof(Company.Name), selectedCompanyId);
        }
    }
}



