using Microsoft.EntityFrameworkCore;

namespace Encounter.Entities
{
    public class EncounterDbContext : DbContext
    {
        public EncounterDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
