using Microsoft.EntityFrameworkCore;

namespace OrderCompositor.Entities
{
	public class OrderCompositorDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{			
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=OrderCompositorDb;");
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
