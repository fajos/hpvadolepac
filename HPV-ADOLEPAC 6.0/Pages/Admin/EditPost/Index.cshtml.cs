using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.EditPost
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public IndexModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PostTestQuestions> PostTestQuestions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PostTestQuestions != null)
            {
                PostTestQuestions = await _context.PostTestQuestions.ToListAsync();
            }
        }
    }
}
