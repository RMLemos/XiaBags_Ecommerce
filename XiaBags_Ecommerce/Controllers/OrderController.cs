using Microsoft.AspNetCore.Mvc;
using XiaBags_Ecommerce.Models;
using XiaBags_Ecommerce.Repositories.Interfaces;

namespace XiaBags_Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int orderTotalItems = 0;
            decimal orderTotalPrice = 0.0m;

            //obtem os itens do carrinho de compra do cliente
            List<ShoppingCartItem> items = _shoppingCart.GetCartItems();
            _shoppingCart.CartItems = items;

            //verifica se existem itens no pedido
            if (_shoppingCart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.");
            }

            //calcula o total de itens e o total do pedido
            foreach (var item in items)
            {
                orderTotalItems += item.Quantity;
                orderTotalPrice += (item.Product.Price * item.Quantity);
            }

            //atribui os valores obtidos ao pedido
            order.TotalItemsOrder = orderTotalItems;
            order.TotalOrder = orderTotalPrice;

            //valida os dados do pedido
            if (ModelState.IsValid)
            {
                //cria o pedido e os detalhes
                _orderRepository.CreateOrder(order);

                //define mensagens ao cliente
                ViewBag.CheckoutCompleteMessage = "Thank you.";
                ViewBag.TotalOrder = _shoppingCart.GetTotalCart();

                //limpa o carrinho do cliente
                _shoppingCart.CleanCart();

                //exibe a view com dados do cliente e do pedido
                return View("~/Views/Order/CheckoutComplete.cshtml", order);
            }
            return View(order);
        }
    }
}
