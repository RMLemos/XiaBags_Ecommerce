using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product GetProductById(int productid);
    }
}
