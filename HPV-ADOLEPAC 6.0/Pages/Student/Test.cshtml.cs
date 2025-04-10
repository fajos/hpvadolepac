using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HPV_ADOLEPAC_6._0.Models;

namespace HPV_ADOLEPAC_6._0.Pages.Student
{
    [Authorize(Roles = "Student")]
    [BindProperties]
    public class TestModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public TestModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TestQuestions> TestQuestions { get; set; } = default!;

        //User input bind here:
        public IList<TestAnswers> TestAnswers { get; set; } = default!;

        public IList<TestAnswers> Answers { get; set; } = default!;
        public bool IsSubmitted { get; set; } = false;
        public int FinalGrade { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.TestQuestions != null)
            {
                TestQuestions = await _context.TestQuestions.ToListAsync();

            }


            string username = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["username"] = username;


            //check if the user already had post test answer in database. if not, create new answer.
            foreach (var question in TestQuestions)
            {
                var answer = await _context.TestAnswers.FirstOrDefaultAsync(m => m.TestQuestionID == question.TestQuestionID && m.Username == username);
                if (answer == null)
                {

                    var newAnswer = new TestAnswers
                    {
                        TestQuestionID = question.TestQuestionID,
                        Username = username
                    };

                    _context.TestAnswers.Add(newAnswer);
                    await _context.SaveChangesAsync();
                }
            }

            //get answers from database. This Answers are passed to razor page.
            Answers = _context.TestAnswers.Where(m => m.Username == username).ToList();

        }


        public async Task<IActionResult> OnPostAsync()
        {

            string username = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["username"] = username;

            Answers = await _context.TestAnswers.Where(m => m.Username == username).Include(m => m.TestQuestions).ToListAsync();

            int correctAnswers = 0;

            for (int i = 0; i < TestAnswers.Count; i++)
            {
                Answers[i].Answer = TestAnswers[i].Answer;
                Answers[i].DateAttempt = DateTime.Today;

                if (Answers[i].Answer == Answers[i].TestQuestions.CorrectOption)
                {
                    correctAnswers++;
                    Answers[i].AnswerStatus = "Correct";

                }
                else { Answers[i].AnswerStatus = "Incorrect"; }
            }

            FinalGrade = (int)((correctAnswers / (double)TestAnswers.Count) * 100);
            IsSubmitted = true;

            var student = _context.student.FirstOrDefault(s => s.StudentUserName == username);
            if (student != null)
            {
                student.FinalGrade = FinalGrade;

            }
            student.KnowledgeTestCompleted = true;
            await _context.SaveChangesAsync();


            return RedirectToPage("/Student/Education");
        }

    }
}
