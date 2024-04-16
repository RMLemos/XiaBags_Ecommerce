using Microsoft.AspNetCore.Mvc;
using XiaBags_Ecommerce.Models;
using XiaBags_Ecommerce.Repositories.Interfaces;
using XiaBags_Ecommerce.ViewModels;

namespace XiaBags_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productrepository)
        {
            _productRepository = productrepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(category))
            {
                products =_productRepository.Products.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.Products
                    .Where(c => c.Category.CategoryName.Equals(category))
                    .OrderBy(c => c.Name);
                currentCategory = category;
            }
            var productsListViewModel = new ProductListViewModel()
            {
                Products = products,
                CurrentCategory = currentCategory,
            };
            return View(productsListViewModel);
        }

        public IActionResult Details(int productid)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productid);
            return View(product);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.Products
                           .Where(p => p.Name.ToLower().Contains(searchString.ToLower()));

                if (products.Any())
                    currentCategory = "Products";
                else
                    currentCategory = "No products found";
            }
            return View("~/Views/Product/List.cshtml", new ProductListViewModel
            {
                Products=products,
                CurrentCategory = currentCategory
            });
        }
    }
}
