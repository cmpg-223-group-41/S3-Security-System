using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using S3_Security_System.Areas.Identity.Data;


namespace S3_Security_System.Models
{
    public class Staff : S3_Security_SystemUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string StaffFirstName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string StaffLastName { get; set; } = string.Empty;
        [Required]
        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position? Position { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime? StaffDateOfBirth { get; set; }
        [Display(Name = "Address")]
        public string? StaffAddress { get; set; }
        [Display(Name = "City")]
        public int? StaffCityId { get; set; }
        [ForeignKey("StaffCityId")]
        public City? StaffCity { get; set; }
        [Display(Name = "Province")]
        public int? StaffProvinceId { get; set; }
        [ForeignKey("StaffProvinceId")]
        public Province? StaffProvince { get; set; }
        [Display(Name = "Zip Code")]
        public string? StaffZip { get; set; }
        [Display(Name = "Next Of Kin")]
        public string? StaffNextOfKinContactName { get; set; }
        [Display(Name = "Next Of Kin Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? StaffNextOfKinContactNo { get; set; }
    }
  
}
