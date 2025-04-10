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
using OfficeOpenXml; // Include EPPlus namespace for Excel file generation

namespace HPV_ADOLEPAC_6._0.Pages.Admin.StudentRecords
{
    [Authorize(Roles = "Admin")] // Ensure only users with the "Admin" role can access the page
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // List to hold the filtered student records
        public IList<student> student { get; set; } = default!;

        // Property to bind the search string from query parameters
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        // Handle GET requests and filter the list of students based on SearchString
        public async Task OnGetAsync()
        {
            // Fetch the filtered list of students
            student = await GetFilteredStudentRecords(SearchString).ToListAsync();
        }

        // Method to get filtered student records
        private IQueryable<student> GetFilteredStudentRecords(string searchString)
        {
            // Start with all student records (queryable)
            var studentQuery = _context.student.AsQueryable();

            // Apply search filter if SearchString is not empty
            if (!string.IsNullOrEmpty(searchString))
            {
                studentQuery = studentQuery.Where(s =>
                    s.StudentUserName.Contains(searchString) ||
                    s.StudentParentName.Contains(searchString) ||
                    s.StudentEmail.Contains(searchString) ||
                    s.StudentParentPhone.Contains(searchString) ||
                    s.StudentGender.Contains(searchString) ||
                    s.StudentAge.ToString().Contains(searchString) ||
                    s.School.Contains(searchString) ||
                    s.Grade.ToString().Contains(searchString) ||
                    s.Religion.Contains(searchString) ||
                    s.EthinicGroup.Contains(searchString) ||
                    s.ParentalMaritalStatus.Contains(searchString) ||
                    s.FatherEdulevel.Contains(searchString) ||
                    s.MotherEdulevel.Contains(searchString) ||
                    s.FatherOccupation.Contains(searchString) ||
                    s.MotherOccupation.Contains(searchString) ||
                    s.MonthlyIncome.Contains(searchString) ||
                    s.AnnualIncome.Contains(searchString) ||
                    s.DeviceOwnership.Contains(searchString) ||
                    s.FrequencySub.Contains(searchString) ||
                    s.ModulePercentage.ToString().Contains(searchString) ||
                    s.AnswerBrief.Contains(searchString) ||
                    s.FinalGrade.ToString().Contains(searchString));
            }

            // Return the filtered query
            return studentQuery;
        }

        // Method to handle POST requests for exporting data to Excel
        public IActionResult OnPostExport()
        {
            // Fetch filtered student list
            var students = GetFilteredStudentRecords(SearchString).ToList();

            if (students.Count == 0)
            {
                TempData["Message"] = "No records found to export.";
                return RedirectToPage(); // If no records found, redirect with a message
            }

            // Create Excel package using EPPlus
            using (var package = new ExcelPackage())
            {
                // Add a worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("StudentRecords");

                // Add the header row
                worksheet.Cells[1, 1].Value = "Username";
                worksheet.Cells[1, 2].Value = "Parent's Name";
                worksheet.Cells[1, 3].Value = "Parent's Email";
                worksheet.Cells[1, 4].Value = "Parent's Phone";
                worksheet.Cells[1, 5].Value = "Gender";
                worksheet.Cells[1, 6].Value = "Age";
                worksheet.Cells[1, 7].Value = "School";
                worksheet.Cells[1, 8].Value = "Grade";
                worksheet.Cells[1, 9].Value = "Religion";
                worksheet.Cells[1, 10].Value = "Ethnic Group";
                worksheet.Cells[1, 11].Value = "Parental Marital Status";
                worksheet.Cells[1, 12].Value = "Father's Education Level";
                worksheet.Cells[1, 13].Value = "Mother's Education Level";
                worksheet.Cells[1, 14].Value = "Father's Occupation";
                worksheet.Cells[1, 15].Value = "Mother's Occupation";
                worksheet.Cells[1, 16].Value = "Monthly Income";
                worksheet.Cells[1, 17].Value = "Annual Income";
                worksheet.Cells[1, 18].Value = "Device Ownership";
                worksheet.Cells[1, 19].Value = "Wifi Payment Frequency";

                // Add the data rows
                for (int i = 0; i < students.Count; i++)
                {
                    var row = i + 2; // Data starts at row 2
                    var student = students[i];
                    worksheet.Cells[row, 1].Value = student.StudentUserName;
                    worksheet.Cells[row, 2].Value = student.StudentParentName;
                    worksheet.Cells[row, 3].Value = student.StudentEmail;
                    worksheet.Cells[row, 4].Value = student.StudentParentPhone;
                    worksheet.Cells[row, 5].Value = student.StudentGender;
                    worksheet.Cells[row, 6].Value = student.StudentAge;
                    worksheet.Cells[row, 7].Value = student.School;
                    worksheet.Cells[row, 8].Value = student.Grade;
                    worksheet.Cells[row, 9].Value = student.Religion;
                    worksheet.Cells[row, 10].Value = student.EthinicGroup;
                    worksheet.Cells[row, 11].Value = student.ParentalMaritalStatus;
                    worksheet.Cells[row, 12].Value = student.FatherEdulevel;
                    worksheet.Cells[row, 13].Value = student.MotherEdulevel;
                    worksheet.Cells[row, 14].Value = student.FatherOccupation;
                    worksheet.Cells[row, 15].Value = student.MotherOccupation;
                    worksheet.Cells[row, 16].Value = student.MonthlyIncome;
                    worksheet.Cells[row, 17].Value = student.AnnualIncome;
                    worksheet.Cells[row, 18].Value = student.DeviceOwnership;
                    worksheet.Cells[row, 19].Value = student.FrequencySub;
                }

                // Convert the Excel package to a byte array
                var fileBytes = package.GetAsByteArray();

                // Return the Excel file as a downloadable file
                var fileName = "StudentRecords.xlsx";
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
    }
}
