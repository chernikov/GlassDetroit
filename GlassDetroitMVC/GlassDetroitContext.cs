using GlassDetroitMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GlassDetroitMVC
{
    public class GlassDetroitContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<SubOrder> SubOrders { get; set; }

        public DbSet<Person> Persons { get; set; }

        public GlassDetroitContext(DbContextOptions<GlassDetroitContext> options) : base(options)
        {
        }
    }
}