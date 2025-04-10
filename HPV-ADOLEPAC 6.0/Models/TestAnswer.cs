using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class TestAnswers
    {
        [Key]
        [Required(ErrorMessage = "Required Field")]
        public int TestAnswerID { get; set; }
        public string? Username { get; set; }
        [ForeignKey(nameof(TestQuestions))]
        public int? TestQuestionID { get; set; }

        public TestQuestions? TestQuestions { get; set; }

        public string? AnswerStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAttempt { get; set; } = DateTime.Now;

        public string? Answer { get; set; }




        public student? FinalGrade { get; set; }
    }
}
