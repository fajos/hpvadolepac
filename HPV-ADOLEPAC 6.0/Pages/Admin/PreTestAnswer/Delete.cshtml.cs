using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;
using System.Xml.Linq;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.PreTestAnswer
{
    public class DeleteModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DeleteModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PreTestAnswer == null)
            {
                return NotFound();
            }
            var pretestanswer = await _context.PreTestAnswer.FindAsync(id);

            if (pretestanswer != null)
            {
                PreTestAnswer = pretestanswer;
                _context.PreTestAnswer.Remove(PreTestAnswer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
