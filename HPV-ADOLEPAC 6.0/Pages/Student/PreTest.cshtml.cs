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
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace HPV_ADOLEPAC_6._0.Pages.Student
{
    [Authorize(Roles = "Student")]
    [BindProperties]
    public class PreTestModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public PreTestModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PreTestQuestions> PreTestQuestions { get; set; } = default!;

        //User input bind here:
        public IList<PreTestAnswers> PreTestAnswers { get; set; } = default!;

        public IList<PreTestAnswers> Answers { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.PreTestQuestions != null)
            {
                PreTestQuestions = await _context.PreTestQuestions.ToListAsync();

            }


            string username = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["username"] = username;


            //check if the user already had post test answer in database. if not, create new answer.
            foreach (var question in PreTestQuestions)
            {
                var answer = await _context.PreTestAnswer.FirstOrDefaultAsync(m => m.PreTestQuestionID == question.PreTestQuestionID && m.Username == username);
                if (answer == null)
                {

                    var newAnswer = new PreTestAnswers
                    {
                        PreTestQuestionID = question.PreTestQuestionID,
                        Username = username
                    };

                    _context.PreTestAnswer.Add(newAnswer);
                    await _context.SaveChangesAsync();
                }
            }

            //get answers from database. This Answers are passed to razor page.
            Answers = _context.PreTestAnswer.Where(m => m.Username == username).ToList();

        }


        public async Task<IActionResult> OnPostAsync()
        {

            string username = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["username"] = username;
            var student = await _context.student.FirstOrDefaultAsync(s => s.StudentUserName == username);
            
                Answers = _context.PreTestAnswer.Where(m => m.Username == username).ToList();

            for (int i = 0; i < PreTestAnswers.Count; i++)
            {
                Answers[i].Answer = PreTestAnswers[i].Answer;
                Answers[i].DateAttempt = DateTime.Today;
            }

            student.PreTestCompleted = true;
            await _context.SaveChangesAsync();


            return RedirectToPage("/Student/Education");
        }

    }
}
