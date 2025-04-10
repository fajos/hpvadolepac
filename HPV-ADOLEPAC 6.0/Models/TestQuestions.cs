using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class TestQuestions
    {
        [Required(ErrorMessage = "Required Field")]
        [Key]
        public int TestQuestionID { get; set; }
        [Display(Name = "Test Question")]
        [Required(ErrorMessage = "Required Field")]
        public string TestQuestion { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Option 1")]
        public string TestQuestionOption1 { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Option 2")]
        public string TestQuestionOption2 { get; set; }
        [Display(Name = "Option 3")]
        public string? TestQuestionOption3 { get; set; }
        [Display(Name = "Option 4")]
        public string? TestQuestionOption4 { get; set; }

        [Display(Name = "Correct Option")]
        public string? CorrectOption { get; set; }

        //show this feedback when the answer is wrong
        public string? Feedback { get; set; }
        public ICollection<TestAnswers>? TestAnswers { get; set; }
    }
}
