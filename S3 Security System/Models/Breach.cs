using S3_Security_System.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S3_Security_System.Models
{
    public class Breach
    {
        public int ID { get; set; }
        [Display(Name = "Staff")]
        public string? S3_Security_SystemUserId { get; set; }
        [ForeignKey("S3_Security_SystemUserId")]
        public S3_Security_SystemUser? S3_Security_SystemUser { get; set; }
        [Display(Name = "Breach Type")]
        [Required]
        public int BreachTypeId { get; set; }
        [ForeignKey("BreachTypeId")]
        public BreachType? BreachType { get; set; }
        [Required]
        [Display(Name = "Breach Response")]
        public string? BreachResp { get; set; }
        [Display(Name = "Date Occured")]
        [DataType(DataType.DateTime)]
        public DateTime? DateAndTime { get; set; }
    }

    public class BreachType
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Breach Type")]
        public string? BreachTypeName { get; set; }
        [Display(Name = "Breach Description")]
        [DataType(DataType.MultilineText)]
        public string? BreachDesc { get; set; }
    }
}
