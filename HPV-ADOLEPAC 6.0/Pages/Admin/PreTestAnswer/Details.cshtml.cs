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

namespace HPV_ADOLEPAC_6._0.Pages.Admin.PreTestAnswer
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DetailsModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public PreTestAnswers PreTestAnswer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PreTestAnswer == null)
            {
                return NotFound();
            }

            var pretestanswer = await _context.PreTestAnswer.FirstOrDefaultAsync(m => m.PreTestAnswerID == id);
            if (pretestanswer == null)
            {
                return NotFound();
            }
            else 
            {
                PreTestAnswer = pretestanswer;
            }
            return Page();
        }
    }
}
