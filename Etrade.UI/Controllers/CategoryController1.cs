using Etrade.DAL.Abstract;
using Etrade.DAL.Concrete;
using Etrade.Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly ICategoryDAL categoryDAL;
        //CategoryDAL categoryDAL1 = new CategoryDAL();

        public CategoryController1(ICategoryDAL categoryDAL)
        {
            this.categoryDAL = categoryDAL;
        }

        public IActionResult Index() //=> View(categoryDAL.GetAll());
        {
            return View(categoryDAL.GetAll());
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                categoryDAL.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = categoryDAL.Get(id);
            if (id == null || category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryDAL.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Details(int id)
        {
            var category = categoryDAL.Get(id);
            if (id == null || category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = categoryDAL.Get(id);
            if (id == null || category == null)
                return NotFound();

            //categoryDAL.Delete(id);
            categoryDAL.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
