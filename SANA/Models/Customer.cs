namespace SANA
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Customers")]
	public class Customer
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId { get; set; }
		[StringLength(65)]
		[Column(TypeName = "VARCHAR")]
		public String FullName { get; set; }
		[StringLength(100)]
		[Column(TypeName = "VARCHAR")]
		public String Address { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}