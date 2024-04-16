using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order); 
    }
}
