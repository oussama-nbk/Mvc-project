using CourceMvc.Data;
using CourceMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CourceMvc.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbcontext context;

        public CategoryController(ApplicationDbcontext db)
        {
            context = db;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList = context.Categories.ToList();
            return View(CategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {


            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order cannot be the same.");
            }

            if (ModelState.IsValid)
            {
                context.Categories.Add(obj);
                context.SaveChanges();
                TempData["success"] = "Add with sucess";
                return RedirectToAction("Index");

            }
            return View();

        }
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category CatEdit = context.Categories.Find(id);
            if (CatEdit == null)
            {
                return NotFound();
            }
            return View(CatEdit);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {


            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order cannot be the same.");
            }

            if (ModelState.IsValid)
            {
                context.Categories.Update(obj);
                context.SaveChanges();
                TempData["success"] = "Update with sucess";

                return RedirectToAction("Index");

            }
            return View();

        }

        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category CatEdit = context.Categories.Find(id);
            if (CatEdit == null)
            {
                return NotFound();
            }
            return View(CatEdit);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {

            Category obj = context.Categories.Find(id);
            if (obj == null) { return NotFound(); }
            context.Categories.Remove(obj);
            context.SaveChanges();
            TempData["success"] = "Delete with sucess";
            return RedirectToAction("Index");
        }
    }
}
