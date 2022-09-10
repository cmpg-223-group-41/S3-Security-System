using System.ComponentModel.DataAnnotations;

namespace S3_Security_System.Models
{
    public class City
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string? CityName { get; set; }
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }
    }
}
