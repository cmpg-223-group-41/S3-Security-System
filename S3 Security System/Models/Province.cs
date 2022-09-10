using System.ComponentModel.DataAnnotations;


namespace S3_Security_System.Models
{
    public class Province
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Province")]
        public string? ProvinceName { get; set; }
    }
}
