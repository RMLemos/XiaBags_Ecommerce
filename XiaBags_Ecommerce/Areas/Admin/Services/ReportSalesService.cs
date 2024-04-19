using Microsoft.EntityFrameworkCore;
using XiaBags_Ecommerce.Context;
using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.Areas.Admin.Services
{
    public class ReportSalesService
    {
        private readonly AppDbContext context;
        public ReportSalesService(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Order>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in context.Orders select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.OrderSentDate >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.OrderSentDate <= maxDate.Value);
            }
            return await result
                         .Include(p => p.ItemsOrder)
                         .ThenInclude(p => p.Product)
                         .OrderByDescending(x => x.OrderSentDate)
                         .ToListAsync();
        }
    }
}
