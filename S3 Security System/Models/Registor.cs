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
        [Required]
        public string TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Staff? Teacher { get; set; }
        [Display(Name = "Students Present")]
        public List<Student> StudentsPresent { get; set; }
    }
}
