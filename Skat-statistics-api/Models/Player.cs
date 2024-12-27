using System.ComponentModel.DataAnnotations;
namespace Skat_statistics_api.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(60)]
        [Required]
        public required string Name { get; set; }
    }
}
