using HPV_ADOLEPAC_6._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace HPV_ADOLEPAC_6._0.Pages.Student
{
    [Authorize(Roles = "Student")]
    public class MyProfileModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public MyProfileModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public student? Myself { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // retrieve the logged-in user's email
            // need to add "using System.Security.Claims;"
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            student Student = await _context.student.FirstOrDefaultAsync(m => m.StudentUserName == _email);

            /* dealing with both cases of new user and existing user */
            if (Student != null)
            {
                // existing user
                ViewData["ExistInDB"] = "true";
                Myself = Student;
            }
            else
            {
                // new user
                ViewData["ExistInDB"] = "false";
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // retrieve the logged-in user's email
            // need to add "using System.Security.Claims;"
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            student Student = await _context.student.FirstOrDefaultAsync(m => m.StudentUserName == _email);

            /* dealing with both cases of new user and existing user */
            if (Student != null)
            {
                // This ViewData entry is needed in the content file
                // The user has been created in the database
                ViewData["ExistInDB"] = "true";
            }
            else
            {
                // new user
                ViewData["ExistInDB"] = "false";
                Student = new student();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            /* for preventing overposting attacks */
            Student.StudentEmail = _email;

            /* movieGoer: the object to update using the values submitted.
             * "MovieGoer": the Prefix used in the input names in web form.
             * Lambda expression: list the properties to be updated. If not listed, 
             *                    no updates, thus preventing overposting.
             */
            var success = await TryUpdateModelAsync<student>(Student, "Myself", s => s.StudentUserName,
                                s => s.StudentEmail, s => s.StudentParentPhone, s => s.StudentParentName, s => s.StudentGender, s => s.StudentAge, s => s.School, s => s.Grade,
                                s => s.Religion, s => s.EthinicGroup, s => s.ParentalMaritalStatus, s => s.FatherEdulevel, s => s.MotherEdulevel,
                                s => s.FatherOccupation, s => s.MotherOccupation, s => s.MonthlyIncome, s => s.AnnualIncome, s => s.DeviceOwnership,
                                s => s.FrequencySub, s => s.ModulePercentage, s => s.AnswerBrief, s => s.FinalGrade);
            if (!success)
            {

                return Page();

            }

            if ((string)ViewData["ExistInDB"] == "true")
            {
                // Since the context doesn't allow tracking two objects with the same key,
                // we do the copying first, and then update.
              
                _context.student.Update(Student);
            }
            else
            {
           
                // add this newly-created record into db
                _context.student.Add(Student);
            }

            try  // catching the conflict of editing this record concurrently
            {
                Student.MyProfileCompleted = true;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            ViewData["SuccessDB"] = "success";
            return Page();
        }


    }
}