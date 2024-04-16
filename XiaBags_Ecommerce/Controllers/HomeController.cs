using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XiaBags_Ecommerce.Models;
using XiaBags_Ecommerce.Repositories.Interfaces;
using XiaBags_Ecommerce.ViewModels;

namespace XiaBags_Ecommerce.Controllers
{

    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LatestProducts = _productRepository.Products.OrderBy(c => c.CreatedAt).Take(9) //Take() limit number of items in a list
            };
            return View(homeViewModel);
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
