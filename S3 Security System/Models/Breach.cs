using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S3_Security_System.Models
{
    public class Breach
    {
        public int ID { get; set; }
        [Display(Name = "Staff")]
        [Required]
        public string StaffId { get; set; }
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }
        [Display(Name = "Breach Type")]
        [Required]
        public int BreachTypeId { get; set; }
        [ForeignKey("BreachTypeId")]
        public BreachType BreachType { get; set; }
        [Required]
        [Display(Name = "Breach Response")]
        public string? BreachResp { get; set; }
        [Required]
        [Display(Name = "Date Occured")]
        [DataType(DataType.DateTime)]
        public DateTime DateAndTime { get; set; }
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
