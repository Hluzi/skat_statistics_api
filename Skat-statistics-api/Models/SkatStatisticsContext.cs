namespace Skat_statistics_api.Models
{
    public class SkatStatisticsContext : DbContext
    {
        public SkatStatisticsContext(DbContextOptions<SkatStatisticsContext> options)
            : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
    }
}
