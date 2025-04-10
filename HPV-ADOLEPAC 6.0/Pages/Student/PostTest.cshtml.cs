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
    [BindProperties]
    public class PostTestModel : PageModel
    {
        private readonly HPV_ADOLEPAC_6._0.Data.ApplicationDbContext _context;

        public PostTestModel(HPV_ADOLEPAC_6._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PostTestQuestions> PostTestQuestions { get; set; } = default!;

        //User input bind here:
        public IList<PostTestAnswer> PostTestAnswers { get; set; } = default!;

        public IList<PostTestAnswer> Answers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PostTestQuestions != null)
            {
                PostTestQuestions = await _context.PostTestQuestions.ToListAsync();

            }

            //get username
            string username = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["username"] = username;


            //check if the user already had post test answer in database. if not, create new answer.
            foreach (var question in PostTestQuestions)
            {
                var answer = await _context.PostTestAnswer.FirstOrDefaultAsync(m => m.PostTestQuestionID == question.PostTestQuestionID && m.Username == username);
                if (answer == null)
                {

                    var newAnswer = new PostTestAnswer
                    {
                        PostTestQuestionID = question.PostTestQuestionID,
                        Username = username
                    };

                    _context.PostTestAnswer.Add(newAnswer);
                    await _context.SaveChangesAsync();
                }
            }

            //get answers from database. This Answers are passed to razor page.
            Answers = _context.PostTestAnswer.Where(m => m.Username == username).ToList();

        }


        public async Task<IActionResult> OnPostAsync()
        {

            string username = User.FindFirst(ClaimTypes.Name).Value;
            ViewData["username"] = username;
            var student = _context.student.FirstOrDefault(s => s.StudentUserName == username);
            Answers = _context.PostTestAnswer.Where(m => m.Username == username).ToList();

            for (int i = 0; i < PostTestAnswers.Count; i++)
            {
                Answers[i].Answer = PostTestAnswers[i].Answer;
                Answers[i].DateAttempt = DateTime.Today;
            }

            student.PostTestCompleted = true;
            await _context.SaveChangesAsync();


            return RedirectToPage("/Student/Education");
        }

    }
}
