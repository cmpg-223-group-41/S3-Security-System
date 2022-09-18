using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using S3_Security_System.Areas.Identity.Data;

namespace S3_Security_System.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string? S3_Security_SystemUserId { get; set; }
        public virtual S3_Security_SystemUser? S3_Security_SystemUser { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string StudentFirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string StudentLastName { get; set; } = string.Empty;
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? StudentDateOfBirth { get; set; }
        [Display(Name = "Current Grade")]
        [Required]
        public int? CurrentGrade { get; set; }
        [Display(Name = "Address")]
        public string? StudentAddress { get; set; }
        [Display(Name = "City")]
        public int? StudentCityId { get; set; }
        [ForeignKey("StudentCityId")]
        public City? StudentCity { get; set; }
        [Display(Name = "Province")]
        public int? StudentProvinceId { get; set; }
        [ForeignKey("StudentProvinceId")]
        public Province? StudentProvince { get; set; }
        [Display(Name = "Zip Code")]
        public string? StudentZip { get; set; }
        [Display(Name = "Parent Name")]
        public string? ParentName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Parent Email")]
        public string? ParentEmail { get; set; }
        [Display(Name = "Next Of Kin")]
        public string? StudentNextOfKinContactName { get; set; }
        [Display(Name = "Next Of Kin Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? StudentNextOfKinContactNo { get; set; }
    }
}
