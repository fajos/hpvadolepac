using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HPV_ADOLEPAC_6._0.Pages.Student
{
    public class mod5Model : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public mod5Model(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task OnGetAsync()
        {
            string username = User.FindFirst(ClaimTypes.Name).Value;
            var student = await _context.student.FirstOrDefaultAsync(s => s.StudentUserName == username);
            student.LearningModulesCompleted = true;
            await _context.SaveChangesAsync();

        }
    }
}
