namespace SANA
{
using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;


	[Table("ProductsCategories")]
	public class ProductsCategory
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int CategoryID { get; set; }
		public int ProductID { get; set; }
		[ForeignKey("CategoryID")]
		public virtual Category Category { get; set; }
		[ForeignKey("ProductID")]
		public virtual Product Product { get; set; }
		
	}
}