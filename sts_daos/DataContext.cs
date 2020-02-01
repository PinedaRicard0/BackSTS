using Microsoft.EntityFrameworkCore;
using sts_models;

namespace sts_daos
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<Team> Teams { get; set; }


    }
}
