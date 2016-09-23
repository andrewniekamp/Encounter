using Microsoft.EntityFrameworkCore;

namespace Reciprocity.Entities
{
    public class ReciprocityDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
