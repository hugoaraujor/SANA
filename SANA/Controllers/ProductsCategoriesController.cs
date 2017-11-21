using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SANA;

namespace SANA.Controllers
{
    public class ProductsCategoriesController : Controller
    {
        private Sana db = new Sana();

        // GET: ProductsCategories
        public ActionResult Index()
        {
            return View(db.ProductsCategories.ToList());
        }

        // GET: ProductsCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsCategory productsCategory = db.ProductsCategories.Find(id);
            if (productsCategory == null)
            {
                return HttpNotFound();
            }
            return View(productsCategory);
        }

        // GET: ProductsCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsCategories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] ProductsCategory productsCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductsCategories.Add(productsCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsCategory);
        }

        // GET: ProductsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsCategory productsCategory = db.ProductsCategories.Find(id);
            if (productsCategory == null)
            {
                return HttpNotFound();
            }
            return View(productsCategory);
        }

        // POST: ProductsCategories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] ProductsCategory productsCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productsCategory);
        }

        // GET: ProductsCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsCategory productsCategory = db.ProductsCategories.Find(id);
            if (productsCategory == null)
            {
                return HttpNotFound();
            }
            return View(productsCategory);
        }

        // POST: ProductsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsCategory productsCategory = db.ProductsCategories.Find(id);
            db.ProductsCategories.Remove(productsCategory);
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
