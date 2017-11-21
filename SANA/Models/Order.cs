namespace SANA
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

		[Table("Orders")]
		public class Order
		{
			[Key]
			[Column(Order = 1)]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int OrderId { get; set; }
		    [Column(TypeName = "date")]
		    public DateTime? OrderDate { get; set; }
		    public Product Products { get; set; }

	}
}