using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SANA
{
	public class ProductViewModel
	{
		public ProductViewModel()
		{
			CategoryManager CategoriesMngr = new CategoryManager();
			Product = new Product();
			Categories = CategoriesMngr.getCategoriesAll();
			BlankCategory = new Category();
			SelectedCategories = new List<ProductsCategory>();
        }
		public Product Product { get; set; }
		public Category BlankCategory { get; set; }
		public int   newCategory { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<ProductsCategory> SelectedCategories { get; set; }
	}
}