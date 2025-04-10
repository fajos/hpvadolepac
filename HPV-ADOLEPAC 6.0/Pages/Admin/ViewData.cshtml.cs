using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace HPV_ADOLEPAC_6._0.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ViewDataModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
