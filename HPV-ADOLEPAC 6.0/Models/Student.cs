using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string? StudentUserName { get; set; }
        
        public bool MyProfileCompleted { get; set; } = false;
        public bool PreTestCompleted { get; set; } = false;
        public bool LearningModulesCompleted { get; set; } = false;
        public bool KnowledgeTestCompleted { get; set; } = false;
        public bool PostTestCompleted { get; set; } = false;
[Display(Name = "Mum or Dad's Email")]
        public string? StudentEmail { get; set; }
        /*[Display(Name = "What's your First Name?")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z'-]+$", ErrorMessage = "Can only consist of English letters, hyphens, and apostrophes.")]*/
        /*public string? StudentFirstName { get; set; }
        [Display(Name = "What's your Last Name?")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z'-]+$", ErrorMessage = "Can only consist of English letters, hyphens, and apostrophes.")]
        public string? StudentLastName { get; set; }
        */

        [Display(Name = "Mum or Dad's Phone Number")]
        public string? StudentParentPhone { get; set; }

        [Display(Name = "Mum or Dad's FirstName (The one who owns the email/phone number)")]
        public string? StudentParentName { get; set; }

        [Display(Name = "Are you a boy or girl?")]
        [Required(ErrorMessage = "Required Field")]

        public string StudentGender { get; set; }


        [Display(Name = "How old are you?")]
        [Required(ErrorMessage = "Required Field")]
        public int? StudentAge { get; set; }


        [Display(Name = "What school do you go to?")]
        public string? School { get; set; }


        [Display(Name = "What Grade/Year are you in?")]
        [Required(ErrorMessage = "This field is required")]
        public int? Grade { get; set; }

        [Display(Name = "What's your Religion?")]
        public string? Religion { get; set; }
        [Display(Name = "What Language do you speak?")]
        public string? EthinicGroup { get; set; }

        [Display(Name = "How are your Parent's relationship?")]
        public string? ParentalMaritalStatus { get; set; }

        [Display(Name = "How did Dad do in school?")]
        public string? FatherEdulevel { get; set; }

        [Display(Name = "How did Mum do in school?")]
        public string? MotherEdulevel { get; set; }

        [Display(Name = "What does Dad do for work?")]
        public string? FatherOccupation { get; set; }

        [Display(Name = "What does Mum do for work?")]
        public string? MotherOccupation { get; set; }

        [Display(Name = "Much money does the family make in a month?")]
        public string? MonthlyIncome { get; set; }

        [Display(Name = "How rich is your family?")]
        public string? AnnualIncome { get; set; }

        [Display(Name = "Does your parents own a smartphone or computer?")]
        public string? DeviceOwnership { get; set; }

        [Display(Name = "How often does Mum or Dad pay for Wi-Fi?")]
        public string? FrequencySub { get; set; }

        [Display(Name = "Module Percentage")]
        public int? ModulePercentage { get; set; }

        [Display(Name = "Your Chosen Answers")]
        public string? AnswerBrief { get; set; }

        [Display(Name = "Your Score (%)")]
        public int? FinalGrade { get; set; }

        public ICollection<TestAnswers>? TestAnswers { get; set; }
    }
}
