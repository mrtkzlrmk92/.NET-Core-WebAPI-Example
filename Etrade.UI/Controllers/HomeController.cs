using Etrade.DAL.Abstract;
using Etrade.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Etrade.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductDAL productDAL;
        private readonly ICategoryDAL categoryDAL;

        public HomeController(ILogger<HomeController> logger, IProductDAL productDAL, ICategoryDAL categoryDAL)
        {
            _logger = logger;
            this.productDAL = productDAL;
            this.categoryDAL = categoryDAL;
        }

        public IActionResult Index()
        {

            return View(productDAL.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(productDAL.Get(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}