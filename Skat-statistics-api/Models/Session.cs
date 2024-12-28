namespace Skat_statistics_api.Models
{
    public class Session
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime StartSession { get; set; }

        [Required]
        public DateTime EndSession { get; set; }

        [Required]
        public int Player1ID { get; set; }

        [Required]
        public int Player2ID { get; set; }

        [Required]
        public int Player3ID { get; set; }

        [Required]
        public int Player4ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string SeatingOrder { get; set; } // Comma separated list of player IDs ex. "1,2,3,4"

    }
}
