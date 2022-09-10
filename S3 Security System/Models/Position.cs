using System.ComponentModel.DataAnnotations;

namespace S3_Security_System.Models
{
    public class Position
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Position")]
        public string? PositionName { get; set; }
        [Display(Name = "Psition Description")]
        [DataType(DataType.MultilineText)]
        public string? PositionDesc { get; set; }

    }
}
