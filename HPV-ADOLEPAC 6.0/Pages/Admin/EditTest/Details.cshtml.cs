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
    public class DetailsModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public DetailsModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
