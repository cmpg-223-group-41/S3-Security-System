using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using S3_Security_System.Areas.Identity.Data;

namespace S3_Security_System.Models
{
    public class Visitor : S3_Security_SystemUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string VisitorFirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string VisitorLastName { get; set; } = string.Empty;

        [Display(Name = "Reason For Visit")]
        [DataType(DataType.MultilineText)]
        public string? VisitReason { get; set; }
    }
}
