using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SANA
{
	[Table("Categories")]
	public class Category
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }
		[StringLength(45)]
		[Required]
		[Column(TypeName = "VARCHAR")]
		public String CategoryName { get; set; }
	}
}