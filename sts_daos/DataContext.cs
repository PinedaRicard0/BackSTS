using Microsoft.EntityFrameworkCore;
using sts_models.DTO;

namespace sts_daos
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeamStatistics> TeamsStatistics { get; set; }
    }
}
