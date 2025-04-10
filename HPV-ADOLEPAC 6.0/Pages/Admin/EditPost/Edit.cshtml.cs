using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.EditPost
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public EditModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
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

            var posttestquestions =  await _context.PostTestQuestions.FirstOrDefaultAsync(m => m.PostTestQuestionID == id);
            if (posttestquestions == null)
            {
                return NotFound();
            }
            PostTestQuestions = posttestquestions;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PostTestQuestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTestQuestionsExists(PostTestQuestions.PostTestQuestionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostTestQuestionsExists(int id)
        {
          return (_context.PostTestQuestions?.Any(e => e.PostTestQuestionID == id)).GetValueOrDefault();
        }
    }
}
