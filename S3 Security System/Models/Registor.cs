using S3_Security_System.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S3_Security_System.Models
{
    public class Registor
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Teacher")]
        public string? S3_Security_SystemUserId { get; set; }
        [ForeignKey("S3_Security_SystemUserId")]
        
        public S3_Security_SystemUser? S3_Security_SystemUser { get; set; }
        [Display(Name = "Students Present")]
        public List<Student>? StudentsPresent { get; set; }
    }
}
