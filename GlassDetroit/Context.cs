using ApplicationCore.Model;
using System.Data.Entity;
public class Context : DbContext
{
    public DbSet<Item> Items { get; set; }

	public DbSet<Order> Orders { get; set; }

	public DbSet<User> Users { get; set; }

	public Context() : base("Server=(local);Trusted_Connection=True;Database=glass;")
	{

	}
} 