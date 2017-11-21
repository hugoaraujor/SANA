namespace SANA
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class Sana : DbContext
	{
		public Sana(): base("name=SANAConnection")
		{
			this.Configuration.LazyLoadingEnabled = true;
		}
		

		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
	    public virtual DbSet<ProductsCategory> ProductsCategories { get; set; }
	    public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
	}

	
}