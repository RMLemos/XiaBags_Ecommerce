using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {
            var productsListViewMdel = new ProductListViewModel();
            productsListViewMdel.Products = _productRepository.Products;
            productsListViewMdel.CurrentCategory = "Categoria Atual";

            return View(productsListViewMdel);
        }
    }
}
