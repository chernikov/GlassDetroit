using System.Data.Entity;
public class Context : DbContext
{
    public DbSet<Item> Items { get; set; }


	public Context() : base("Server=(local);Trusted_Connection=True;Database=glass;")
	{

	}
} 