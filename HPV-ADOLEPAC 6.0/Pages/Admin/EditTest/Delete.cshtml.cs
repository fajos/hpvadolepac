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
    public class DeleteModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DeleteModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TestQuestions TestQuestions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TestQuestions == null)
            {
                return NotFound();
            }

            var testquestions = await _context.TestQuestions.FirstOrDefaultAsync(m => m.TestQuestionID == id);

            if (testquestions == null)
            {
                return NotFound();
            }
            else 
            {
                TestQuestions = testquestions;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TestQuestions == null)
            {
                return NotFound();
            }
            var testquestions = await _context.TestQuestions.FindAsync(id);

            if (testquestions != null)
            {
                var testAnswers = _context.TestAnswers.Where(a => a.TestQuestionID == id);

                // Remove related TestAnswers entities
                _context.TestAnswers.RemoveRange(testAnswers);

                // Remove the TestQuestions entity
                _context.TestQuestions.Remove(testquestions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
