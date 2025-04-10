using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HPV_ADOLEPAC_6._0.Models
{
    public class Admin
    {
        [Display(Name = "Email Address")]
        [EmailAddress]
        [Required(ErrorMessage = "Required Field")]
        [Key]
        public string? AdminEmail { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z'-]+$", ErrorMessage = "Can only consist of English letters, hyphens, and apostrophes.")]
        public string AdminFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required Field")]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z'-]+$", ErrorMessage = "Can only consist of English letters, hyphens, and apostrophes.")]
        public string AdminLastName { get; set; }
    }
}
