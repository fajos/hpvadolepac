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
    public class DeleteModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DeleteModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PreTestQuestions == null)
            {
                return NotFound();
            }
            var pretestquestions = await _context.PreTestQuestions.FindAsync(id);

            if (pretestquestions != null)
            {
                var preTestAnswers = _context.PreTestAnswer.Where(a => a.PreTestQuestionID == id);

                // Remove related PreTestAnswer entities
                _context.PreTestAnswer.RemoveRange(preTestAnswers);

                // Remove the PreTestQuestions entity
                _context.PreTestQuestions.Remove(pretestquestions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
