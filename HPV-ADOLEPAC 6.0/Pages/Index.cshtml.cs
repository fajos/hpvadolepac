using HPV_ADOLEPAC_6._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HPV_ADOLEPAC_6._0.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        [BindProperty]
        public student? Student { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            string username = User.FindFirst(ClaimTypes.Name)?.Value;

            Student = await _context.student.FirstOrDefaultAsync(s => s.StudentUserName == username);

            if(User.IsInRole("Student"))
            {
                if (Student == null)
                {
                    return RedirectToPage("/Student/MyProfile");
                }
            }
            
            return Page();
        }
    }
}
