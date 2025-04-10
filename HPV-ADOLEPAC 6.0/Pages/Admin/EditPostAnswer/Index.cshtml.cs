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
using OfficeOpenXml; // Include the EPPlus namespace for Excel file generation
using System.IO;

namespace HPV_ADOLEPAC_6._0.Pages.Admin.EditPostAnswer
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
        public IList<PostTestAnswer> PostTestAnswer { get; set; } = new List<PostTestAnswer>(); // Initialize with an empty list

        public async Task OnGetAsync()
        {
            // Ensure that fromDate is not greater than toDate
            if (fromDate > toDate)
            {
                toDate = fromDate;
            }

            // Start building the query for PostTestAnswer
            var answerQuery = _context.PostTestAnswer
                                      .Where(m => m.DateAttempt >= fromDate && m.DateAttempt <= toDate);

            // Apply search filter if SearchString is not empty
            if (!string.IsNullOrEmpty(SearchString))
            {
                answerQuery = answerQuery.Where(s =>
                               s.Answer.Contains(SearchString) ||
                               s.Username.Contains(SearchString) ||
                               s.PostTestQuestions.PostTestQuestion.Contains(SearchString));
            }

            // Check for "Show All Records" button click and clear SearchString if clicked
            var showAllParameter = Request.Query["ShowAll"].ToString();
            if (!string.IsNullOrEmpty(showAllParameter))
            {
                SearchString = string.Empty; // Reset search string
            }

            // Fetch filtered data, ensuring it is not null
            PostTestAnswer = await answerQuery.Include(p => p.PostTestQuestions).ToListAsync();
        }

        // Method to handle Excel export
        public async Task<IActionResult> OnPostExportToExcelAsync()
        {
            // Fetch the filtered data again
            var answerQuery = _context.PostTestAnswer
                                      .Where(m => m.DateAttempt >= fromDate && m.DateAttempt <= toDate);

            if (!string.IsNullOrEmpty(SearchString))
            {
                answerQuery = answerQuery.Where(s =>
                               s.Answer.Contains(SearchString) ||
                               s.Username.Contains(SearchString) ||
                               s.PostTestQuestions.PostTestQuestion.Contains(SearchString));
            }

            var answersToExport = await answerQuery.Include(p => p.PostTestQuestions).ToListAsync();

            // Generate Excel using EPPlus
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("PostTestAnswers");

            // Add the headers
            worksheet.Cells[1, 1].Value = "Username";
            worksheet.Cells[1, 2].Value = "PostTestQuestion";
            worksheet.Cells[1, 3].Value = "Answer";
            worksheet.Cells[1, 4].Value = "DateAttempt";

            // Add the data
            for (int i = 0; i < answersToExport.Count; i++)
            {
                var answer = answersToExport[i];
                worksheet.Cells[i + 2, 1].Value = answer.Username;
                worksheet.Cells[i + 2, 2].Value = answer.PostTestQuestions.PostTestQuestion;
                worksheet.Cells[i + 2, 3].Value = answer.Answer;
                worksheet.Cells[i + 2, 4].Value = answer.DateAttempt.ToString("yyyy-MM-dd");
            }

            // Set column widths
            worksheet.Cells.AutoFitColumns();

            // Return the Excel file as a downloadable file
            var stream = new MemoryStream();
            package.SaveAs(stream);
            var fileName = "PostTestAnswers.xlsx";
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
