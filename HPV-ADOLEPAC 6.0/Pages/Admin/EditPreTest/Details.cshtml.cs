using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.EditPreTest
{
    public class DetailsModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DetailsModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public PreTestQuestions PreTestQuestions { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PreTestQuestions == null)
            {
                return NotFound();
            }

            var pretestquestions = await _context.PreTestQuestions.FirstOrDefaultAsync(m => m.PreTestQuestionID == id);
            if (pretestquestions == null)
            {
                return NotFound();
            }
            else 
            {
                PreTestQuestions = pretestquestions;
            }
            return Page();
        }
    }
}
