using HPV_ADOLEPAC_6._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;


namespace HPV_ADOLEPAC_6._0.Pages.Student
{
    public class EducationModel : PageModel
    {


        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;
        public EducationModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public student? Student { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
           string username = User.FindFirst(ClaimTypes.Name).Value;
            Student = await _context.student.FirstOrDefaultAsync(s => s.StudentUserName == username);

            if (Student == null)
            {
                return RedirectToPage("/Student/MyProfile");
            }
            return Page();
        }



    }
}
