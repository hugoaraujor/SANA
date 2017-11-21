namespace SANA.Controllers
{
	using System.Data;
	using System.Data.Entity;
	using System.Linq;
	using System.Net;
	using System.Web.Mvc;

	public class ProductsController : Controller
	{
		private Sana db = new Sana();

		// GET: Products
		public ActionResult Index()
		{
			return View(db.Products.ToList());
		}

		// GET: Products/Details/5
		public ActionResult Details(int? id, int newCategory = 0)
		{
			ProductViewModel Pvm = new ProductViewModel();
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			AddNewCategory(id, newCategory);
			
			Pvm.Product = product;
			if (product == null)
			{
				return HttpNotFound();
			}
			GetAssociatedCategories(id, Pvm);
			return View(Pvm);
		}

		private void AddNewCategory(int? id, int newCategory)
		{
			if (newCategory != 0)
			{
				var ExistCategoryProduct = db.ProductsCategories.Where(x => x.ProductID == id && x.CategoryID == newCategory).Any();
				if (!ExistCategoryProduct)
				{
					db.ProductsCategories.Add(new ProductsCategory { CategoryID = newCategory, ProductID = id.Value });
					db.SaveChangesAsync();
					
				}
			}
		}

		private void GetAssociatedCategories(int? id, ProductViewModel Pvm)
		{
			Pvm.SelectedCategories = (from c in db.ProductsCategories where c.Product.ProductNumber == id.Value select c);
		}

		// GET: Products/Create
		public ActionResult Create()
		{
			ProductViewModel pvm = new ProductViewModel();
			return View();
		}

		// POST: Products/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ProductNumber,ProductTitle,Price")] Product product)
		{
			if (ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(product);
		}

		// GET: Products/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ProductNumber,ProductTitle,Price")] Product product)
		{
			if (ModelState.IsValid)
			{
				db.Entry(product).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}

		// GET: Products/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = db.Products.Find(id);
			db.Products.Remove(product);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
