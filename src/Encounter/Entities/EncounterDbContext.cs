using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Encounter.Entities
{
    public class EncounterDbContext : IdentityDbContext<ApplicationUser>
    {
        public EncounterDbContext(DbContextOptions options)
            : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Foe> Foes { get; set; }
    }
}
