using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.ViewModels
{
    public class OrderProductViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
