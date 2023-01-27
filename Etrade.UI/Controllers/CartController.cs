using Etrade.DAL.Abstract;
using Etrade.Entities.Models.ViewModel;
using Etrade.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etrade.UI.Controllers
{
    public class CartController : Controller
    {
        IProductDAL productDAL;

        public CartController(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.Total = cart.Sum(item => item.Product.Price * item.Quantity);
            SessionHelper.Count = cart.Count();
            return View(cart);
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.Get<List<CartItem>>(HttpContext.Session,"cart") == null)
            {
                var cart = new List<CartItem>();
                cart.Add(new CartItem() { Product = productDAL.Get(id), Quantity = 1 });
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
                int index = isExits(cart,id);
                if (index < 0)
                    cart.Add(new CartItem() { Product = productDAL.Get(id), Quantity = 1 });
                else
                    cart[index].Quantity++;

                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        private int isExits(List<CartItem> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                    return i;
            }
            return -1;
        }

        public IActionResult Remove(int id)
        {
            var cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExits(cart, id);
            cart.RemoveAt(index);
            SessionHelper.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
