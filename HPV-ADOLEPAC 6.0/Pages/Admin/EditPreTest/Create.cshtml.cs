using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.EditPreTest
{
    public class CreateModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public CreateModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PreTestQuestions PreTestQuestions { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PreTestQuestions == null || PreTestQuestions == null)
            {
                return Page();
            }

            _context.PreTestQuestions.Add(PreTestQuestions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
