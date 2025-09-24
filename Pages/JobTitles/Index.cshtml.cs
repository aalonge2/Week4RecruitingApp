using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitingApp.Data;
using RecruitingApp.Models;

namespace RecruitingApp.Pages.JobTitles
{
    public class IndexModel : PageModel
    {
        private readonly RecruitingApp.Data.ApplicationDbContext _context;

        public IndexModel(RecruitingApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<JobTitle> JobTitle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JobTitle = await _context.JobTitles.ToListAsync();
        }
    }
}
