using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class PostTestQuestions
    {
        [Required(ErrorMessage = "Required Field")]
        [Key]
        public int PostTestQuestionID { get; set; }
        [Display(Name = "Post Test Question")]
        [Required(ErrorMessage = "Required Field")]
        public string? PostTestQuestion { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Option 1")]
        public string? PostTestQuestionOption1 { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Option 2")]
        public string? PostTestQuestionOption2 { get; set; }
        [Display(Name = "Option 3")]
        public string? PostTestQuestionOption3 { get; set; }
        [Display(Name = "Option 4")]
        public string? PostTestQuestionOption4 { get; set; }
        [Display(Name = "Option 5")]
        public string? PostTestQuestionOption5 { get; set; }
    }
}
