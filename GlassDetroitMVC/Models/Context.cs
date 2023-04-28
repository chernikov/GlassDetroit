using Microsoft.EntityFrameworkCore;

namespace GlassDetroitMVC.Models
{
    public class Context : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public Context(DbContextOptions<Context> options) : base (options)
        {
        }
    }
}
