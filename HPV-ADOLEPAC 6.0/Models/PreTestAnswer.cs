using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class PreTestAnswers
    {
        [Key]
        [Required(ErrorMessage = "Required Field")]
        public int PreTestAnswerID { get; set; }

        public string? Answer { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAttempt { get; set; } = DateTime.Now;


        public string? Username { get; set; }


        [ForeignKey(nameof(PreTestQuestions))]
        public int? PreTestQuestionID { get; set; }

        public PreTestQuestions? PreTestQuestions { get; set; }
    }
}
