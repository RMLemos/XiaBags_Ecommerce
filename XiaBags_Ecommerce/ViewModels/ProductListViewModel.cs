using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
