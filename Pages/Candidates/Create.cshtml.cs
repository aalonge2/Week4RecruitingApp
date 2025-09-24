using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        public SelectList JobTitleOptions { get; set; } = default!;
        public SelectList IndustryOptions { get; set; } = default!;
        public SelectList CompanyOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadLookupsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadLookupsAsync();
                return Page();
            }

            _context.Candidates.Add(Candidate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private async Task LoadLookupsAsync()
        {
            var jobTitles = await _context.JobTitles.OrderBy(j => j.Title).ToListAsync();
            var industries = await _context.Industries.OrderBy(i => i.Name).ToListAsync();
            var companies = await _context.Companies.OrderBy(c => c.Name).ToListAsync();

            JobTitleOptions = new SelectList(jobTitles, nameof(JobTitle.JobTitleId), nameof(JobTitle.Title));
            IndustryOptions = new SelectList(industries, nameof(Industry.IndustryId), nameof(Industry.Name));
            CompanyOptions = new SelectList(companies, nameof(Company.CompanyId), nameof(Company.Name));
        }
    }
}

