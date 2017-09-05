using batatafrita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace batatafrita.Controllers
{
    public class CategoriesController : Controller
    {
        
private static IList<Category> categoryList =
   new List<Category> ()
{
                new Category() { CategoryId = 1, Name = "Notebook" },
                new Category() { CategoryId = 2, Name = "Monitores" },
                new Category() { CategoryId = 3, Name = "Printers" },
                new Category() { CategoryId = 4, Name = "Mouses" },
                new Category() { CategoryId = 5, Name = "Laptops" },
            };



        // GET: Categories
        public ActionResult Index()
        {
            return View(categoryList);
        }

        public ActionResult Details(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();

            return View(category);
        }

        public ActionResult Detalhar(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();

            return View(category);
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            categoryList.Add(category);

            category.CategoryId =
                categoryList.Max(c => c.CategoryId) + 1;
            return RedirectToAction("Create");
        }

        #endregion

        #region Edit

        public ActionResult Edit(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category modified)
        {
            var category = categoryList
                .Where(c => c.CategoryId == modified.CategoryId)
                .First();

            category.Name = modified.Name;

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public ActionResult Delete(long id)
        {
            var category = categoryList
                .Where(c => c.CategoryId == id)
                .First();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category toDelete)
        {
            var category = categoryList
                .Where(c => c.CategoryId == toDelete.CategoryId)
                .First();

            categoryList.Remove(category);

            return RedirectToAction("Index");
        }

        #endregion

    }
}