using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class PreTestQuestions
    {
        [Required(ErrorMessage = "Required Field")]
        [Key]
        public int PreTestQuestionID { get; set; }
        [Display(Name = "Pre-Test Question")]
        [Required(ErrorMessage = "Required Field")]
        public string PreTestQuestion { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Option 1")]
        public string PreTestQuestionOption1 { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Option 2")]
        public string PreTestQuestionOption2 { get; set; }
        [Display(Name = "Option 3")]
        public string? PreTestQuestionOption3 { get; set; }
        [Display(Name = "Option 4")]
        public string? PreTestQuestionOption4 { get; set; }
        [Display(Name = "Option 5")]
        public string? PreTestQuestionOption5 { get; set; }

        public ICollection<PreTestAnswers>? PreTestAnswers { get; set; }
    }
}
