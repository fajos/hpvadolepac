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
using System.IO;
using OfficeOpenXml; // Include the EPPlus namespace for Excel file generation

namespace HPV_ADOLEPAC_6._0.Pages.Admin.PreTestAnswer
{
    [Authorize(Roles = "Admin")] // Only users with "Admin" role can access this page
    [BindProperties(SupportsGet = true)] // Enables model binding for GET requests
    public class IndexModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        // Constructor to inject the ApplicationDbContext for database access
        public IndexModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // Lists to hold PreTestAnswers and related PreTestQuestions
        public IList<PreTestAnswers> PreTestAnswer { get; set; } = default!;
        public IList<PreTestQuestions> PreTestQuestions { get; set; } = default!;

        // Properties for search and filtering
        public string SearchString { get; set; } = string.Empty;
        public DateTime fromDate { get; set; } = DateTime.Today.AddDays(-10); // Default fromDate to 10 days ago
        public DateTime toDate { get; set; } = DateTime.Today; // Default toDate to today

        // Handles GET request to fetch filtered data based on search criteria
        public async Task OnGetAsync()
        {
            // Ensure that fromDate is not greater than toDate (to avoid invalid date range)
            if (fromDate > toDate)
            {
                toDate = fromDate;
            }

            // Query to filter PreTestAnswers based on the provided date range
            var answerstring = _context.PreTestAnswer.Where(m => m.DateAttempt >= fromDate && m.DateAttempt <= toDate);

            // Apply search filter based on the SearchString
            if (!string.IsNullOrEmpty(SearchString))
            {
                answerstring = answerstring.Where(s =>
                    s.Answer.Contains(SearchString) ||
                    s.Username.Contains(SearchString) ||
                    s.PreTestQuestions.PreTestQuestion.Contains(SearchString)
                );
            }

            // Handle "Show All Records" button click by clearing the search string
            var showAllParameter = Request.Query["ShowAll"].ToString();
            if (!string.IsNullOrEmpty(showAllParameter))
            {
                SearchString = string.Empty;
            }

            // Fetch the filtered PreTestAnswer including related PreTestQuestions
            PreTestAnswer = await answerstring.Include(p => p.PreTestQuestions).ToListAsync();
        }

        // Method to handle exporting the filtered data to Excel
        public IActionResult OnPostExport()
        {
            // Query for filtering PreTestAnswers based on date range and search string
            var answerstring = _context.PreTestAnswer.Where(m => m.DateAttempt >= fromDate && m.DateAttempt <= toDate);

            // Apply search string filter if it's not empty
            if (!string.IsNullOrEmpty(SearchString))
            {
                answerstring = answerstring.Where(s =>
                    s.Answer.Contains(SearchString) ||
                    s.Username.Contains(SearchString) ||
                    s.PreTestQuestions.PreTestQuestion.Contains(SearchString)
                );
            }

            // Fetch the filtered data including related PreTestQuestions
            var answersToExport = answerstring.Include(p => p.PreTestQuestions).ToList();

            // Use EPPlus to create an Excel package
            using (var package = new ExcelPackage())
            {
                // Add a worksheet to the Excel workbook named "PreTestAnswers"
                var worksheet = package.Workbook.Worksheets.Add("PreTestAnswers");

                // Add headers for the Excel columns
                worksheet.Cells[1, 1].Value = "Username";
                worksheet.Cells[1, 2].Value = "PreTest Question";
                worksheet.Cells[1, 3].Value = "Answer";
                worksheet.Cells[1, 4].Value = "Date Attempt";

                // Add the data for each PreTestAnswer record into the worksheet
                for (var i = 0; i < answersToExport.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = answersToExport[i].Username;
                    worksheet.Cells[i + 2, 2].Value = answersToExport[i].PreTestQuestions.PreTestQuestion;
                    worksheet.Cells[i + 2, 3].Value = answersToExport[i].Answer;
                    worksheet.Cells[i + 2, 4].Value = answersToExport[i].DateAttempt.ToString("yyyy-MM-dd");
                }

                // Convert the Excel package to a byte array
                var fileBytes = package.GetAsByteArray();

                // Return the Excel file as a downloadable file with the .xlsx extension
                var fileName = "PreTestAnswers.xlsx";
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
