using Microsoft.EntityFrameworkCore;
using XiaBags_Ecommerce.Context;
using XiaBags_Ecommerce.Models;
using XiaBags_Ecommerce.Repositories.Interfaces;

namespace XiaBags_Ecommerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;   
        }
        public IEnumerable<Product> Products => _context.Products.Include(c => c.Category);

        public Product GetProductById(int productid)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productid);
        }
    }
}
