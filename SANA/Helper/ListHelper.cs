using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SANA
{
		public partial class ListHelper
		{
			public class SelectListItemHelper
			{
				
				public static IEnumerable<SelectListItem> GetCategorias()
				{
					CategoryManager ec = new CategoryManager();
				    IEnumerable<Category> query = ec.getCategoriesAll();
					List<SelectListItem> items = new List<SelectListItem>();
					foreach (var e in query)
					{
						items.Add(new SelectListItem { Text = e.CategoryName, Value = e.CategoryId.ToString() });
					};
					return items;
				}

			}
		}
	}

