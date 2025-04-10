using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class PostTestAnswer
    {
        [Key]
        [Required(ErrorMessage = "Required Field")]
        public int PostTestAnswerID { get; set; }

        public string? Answer { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAttempt { get; set; } = DateTime.Now;


        public string? Username { get; set; }


        [ForeignKey(nameof(PostTestQuestions))]
        public int? PostTestQuestionID { get; set; }

        public PostTestQuestions? PostTestQuestions { get; set; }
    }
}
