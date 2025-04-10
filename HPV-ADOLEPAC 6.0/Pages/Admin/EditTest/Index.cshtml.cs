using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.EditTest
{
    public class IndexModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public IndexModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TestQuestions> TestQuestions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TestQuestions != null)
            {
                TestQuestions = await _context.TestQuestions.ToListAsync();
            }
        }
    }
}
