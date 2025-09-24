using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Company = await _context.Companies
                .Include(c => c.Industry)
                .FirstOrDefaultAsync(m => m.CompanyId == id);

            if (Company == null) return NotFound();

            await PopulateIndustriesDropDownList(Company.IndustryId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateIndustriesDropDownList(Company?.IndustryId);
                return Page();
            }

            // Attach the posted Company and mark as modified (scaffold pattern)
            _context.Attach(Company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Companies.AnyAsync(e => e.CompanyId == Company.CompanyId))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private async Task PopulateIndustriesDropDownList(int? selectedIndustryId = null)
        {
            var industries = await _context.Industries
                .OrderBy(i => i.Name)
                .ToListAsync();

            ViewData["IndustryId"] = new SelectList(
                items: industries,
                dataValueField: nameof(Industry.IndustryId),
                dataTextField: nameof(Industry.Name),
                selectedValue: selectedIndustryId
            );
        }
    }
}


