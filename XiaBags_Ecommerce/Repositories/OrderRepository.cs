using XiaBags_Ecommerce.Context;
using XiaBags_Ecommerce.Models;
using XiaBags_Ecommerce.Repositories.Interfaces;

namespace XiaBags_Ecommerce.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderSentDate = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.CartItems;
            foreach (var cartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.Product.ProductId,
                    OrderId = order.OrderId,
                    Price = cartItem.Product.Price,
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
