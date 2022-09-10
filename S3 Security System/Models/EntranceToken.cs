using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using S3_Security_System.Areas.Identity.Data;

namespace S3_Security_System.Models
{
    public class EntranceToken
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Date Obtained")]
        [DataType(DataType.Date)]
        public DateTime DateObtained { get; set; }
        [Display(Name = "User")]
        [Required]
        public string? security_systemId { get; set; }
        [Required]
        [ForeignKey("security_systemId")]
        public S3_Security_SystemUser User { get; set; }
        public bool AccessGranted { get; set; }
        [Display(Name = "Time Of Entry")]
        [DataType(DataType.Time)]
        public DateTime TimeOfEntry { get; set; } = DateTime.Now;
        [Display(Name = "Time Of Exit")]
        [DataType(DataType.Time)]
        public DateTime TimeOfExit { get; set; } 
    }
}
