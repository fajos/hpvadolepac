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
    public class DetailsModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DetailsModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public PostTestQuestions PostTestQuestions { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PostTestQuestions == null)
            {
                return NotFound();
            }

            var posttestquestions = await _context.PostTestQuestions.FirstOrDefaultAsync(m => m.PostTestQuestionID == id);
            if (posttestquestions == null)
            {
                return NotFound();
            }
            else 
            {
                PostTestQuestions = posttestquestions;
            }
            return Page();
        }
    }
}
