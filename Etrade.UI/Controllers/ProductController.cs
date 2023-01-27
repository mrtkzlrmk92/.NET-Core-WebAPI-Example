using Etrade.DAL.Abstract;
using Etrade.Entities.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Etrade.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDAL productDAL;
        private readonly ICategoryDAL categoryDAL;

        public ProductController(IProductDAL productDAL, ICategoryDAL categoryDAL)
        {
            this.productDAL = productDAL;
            this.categoryDAL = categoryDAL;
        }

        public IActionResult Index()
        {
            var products = productDAL.GetAll();
            foreach (var item in products)
            {
                item.Category = categoryDAL.Get(item.CategoryId);
            }
            return View(products);
        }

        public IActionResult Create()
        {
            ViewData["CategoryList"] = new SelectList(categoryDAL.GetAll(), "Id", "Name");
               return View();

        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Category = categoryDAL.Get(product.CategoryId);
            if(!ModelState.IsValid) 
            {
                productDAL.Add(product);
                return RedirectToAction("Index");
            }
            ViewData["CategoryList"] = new SelectList(categoryDAL.GetAll(), "Id", "Name");
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            var product= productDAL.Get(id);
            product.Category = categoryDAL.Get(product.CategoryId);
            if (id==null|| product==null) 
            { 
                return NotFound ();
            }
            ViewData["CategoryList"] = new SelectList(categoryDAL.GetAll(), "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            product.Category = categoryDAL.Get(product.CategoryId);
            ViewData["CategoryList"] = new SelectList(categoryDAL.GetAll(), "Id", "Name");
            productDAL.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = productDAL.Get(id);
            if (id == null || product == null)
                return NotFound();

            //productDAL.Delete(id);
            productDAL.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
