using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
