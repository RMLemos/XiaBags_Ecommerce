using XiaBags_Ecommerce.Context;
using XiaBags_Ecommerce.Models;

namespace XiaBags_Ecommerce.Areas.Admin.Services
{
    public class ChartSalesService
    {
        private readonly AppDbContext context;

        public ChartSalesService(AppDbContext context)
        {
            this.context = context;
        }

        public List<ProductChart> GetSalesProducts(int days)
        {
            DateTime date = DateTime.Now.AddDays(- days);


            var products = (from pd in context.OrderDetails
                            join p in context.Products on pd.ProductId equals p.ProductId
                            where pd.Order.OrderDate >= date
                            group pd by new { pd.ProductId, p.Name }
                            into g
                            select new
                            {
                               ProductName = g.Key.Name,
                               ProductsQuantity = g.Sum(q => q.Quantity),
                               ProductsTotalAmount = g.Sum(a => a.Price * a.Quantity)
                            });

            var listV = new List<ProductChart>();

            foreach (var item in products)
            {
                var product = new ProductChart();
                product.ProductName = item.ProductName;
                product.ProductsQuantity = item.ProductsQuantity;
                product.ProductsAmountTotal = item.ProductsTotalAmount;
                listV.Add(product);
            }
            return listV;
        }
    }
}
