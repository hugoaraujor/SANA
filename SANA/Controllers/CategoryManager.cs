
namespace SANA
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Data.Entity.Validation;
	using System.Data;


	public class CategoryManager
	{
		#region Insert

		public void InsertCategory(Category NewCategory)
		{
			
			using (var db = new Sana())
			{
				db.Categories.Add(NewCategory);
				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void Delete(int IdCategory)
		{
			using (var db = new Sana())
			{
				Category query = (from x in db.Categories
								  where x.CategoryId == IdCategory
								  select x).FirstOrDefault<Category>();
				if (query != null)
				{
					db.Categories.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Exist

		public bool Exist(string categoryName)
		{
			bool resp = false;
			using (var db = new Sana())
			{
				Category query = (from x in db.Categories where x.CategoryName == categoryName select x).FirstOrDefault();
				if (query != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion
		public IEnumerable<Category> getCategoriesAll()
		{
			IEnumerable<Category> pac = new List<Category>();
			
				using (var db = new Sana())
				{
				pac = db.Categories;
				return pac.ToList();
			     }
		}

		public Category getCategory(int id)
		{
			Category pac = new Category();

			using (var db = new Sana())
			{
				pac = db.Categories.Where(x=>x.CategoryId==id).SingleOrDefault();
				return pac;
			}
		}



		public void Edit(Category Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Sana())
				{
					var pac = (from p in db.Categories where p.CategoryId == Editedclass.CategoryId select p).FirstOrDefault();
					db.Categories.Attach(pac);
					db.Entry(pac).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
				}

			}
			catch (DbEntityValidationException e)
			{

			}
		}

	}
}
