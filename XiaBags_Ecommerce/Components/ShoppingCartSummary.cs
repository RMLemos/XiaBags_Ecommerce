using Microsoft.AspNetCore.Mvc;
using XiaBags_Ecommerce.Models;
using XiaBags_Ecommerce.ViewModels;

namespace XiaBags_Ecommerce.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetCartItems();
            _shoppingCart.CartItems = items;

            var shoppingCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalCart()
            };
            return View(shoppingCartVM);
        }
    }
}
