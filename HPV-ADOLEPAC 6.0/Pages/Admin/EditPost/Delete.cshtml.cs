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
    public class DeleteModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DeleteModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PostTestQuestions == null)
            {
                return NotFound();
            }
            var posttestquestions = await _context.PostTestQuestions.FindAsync(id);

            if (posttestquestions != null)
            {

                var postTestAnswers = _context.PostTestAnswer.Where(a => a.PostTestQuestionID == id);
                _context.PostTestAnswer.RemoveRange(postTestAnswers);

                _context.PostTestQuestions.Remove(posttestquestions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
