using Microsoft.EntityFrameworkCore;

namespace Reciprocity.Entities
{
    public class ReciprocityDbContext : DbContext
    {
        public ReciprocityDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
