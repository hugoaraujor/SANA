using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SANA
{
	[Table("Products")]
	public class Product
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name = "Product Number")]
		public int ProductNumber { get; set; }
		[Column(TypeName = "VARCHAR")]
		[StringLength(80)]
		[Display(Name = "Product")]
		[Required]
		public String ProductTitle{ get; set;}
		[Required]
		[Range(typeof(decimal),"1","999999")]
	//	[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
		[Display(Name = "Price")]
		public decimal Price { get; set; }
		

	}
}