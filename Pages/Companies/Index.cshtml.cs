using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly RecruitingApp.Data.ApplicationDbContext _context;

        public IndexModel(RecruitingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Companies
                .Include(c => c.Industry)
                .OrderBy(c => c.Name)
                .ToListAsync();


        }
    }
}
