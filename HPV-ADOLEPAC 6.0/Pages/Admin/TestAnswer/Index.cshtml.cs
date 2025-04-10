using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Data;
using HPV_ADOLEPAC_6._0.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.TestAnswer
{
    [Authorize(Roles = "Admin")]
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public IndexModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string SearchString { get; set; } = string.Empty;

        public DateTime fromDate { get; set; } = DateTime.Today.AddDays(-10);

        public DateTime toDate { get; set; } = DateTime.Today;

        public IList<TestAnswers> TestAnswers { get;set; } = default!;
        public IList<TestQuestions> TestQuestions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (fromDate > toDate)
            {
                toDate = fromDate;
            }

            var answerstring = (IQueryable<TestAnswers>)_context.TestAnswers.Where(m => m.DateAttempt >= fromDate &&
                                                            m.DateAttempt <= toDate);

            if (!String.IsNullOrEmpty(SearchString))
            {
                answerstring = answerstring.Where(s => s.Username.Contains(SearchString) || s.TestQuestions.TestQuestion.Contains(SearchString) ||
                            s.AnswerStatus.Contains(SearchString));

            }

            var showAllParameter = Request.Query["ShowAll"].ToString();

            if (!String.IsNullOrEmpty(showAllParameter))
            {
                // Clear the SearchString value
                SearchString = string.Empty;
            }

            if (answerstring != null)
            {
                TestAnswers = await answerstring.Include(p => p.TestQuestions).ToListAsync();
            }
        }
    }
}
