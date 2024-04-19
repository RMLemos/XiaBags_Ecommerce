using Microsoft.AspNetCore.Mvc;
using XiaBags_Ecommerce.Areas.Admin.Services;

namespace XiaBags_Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminChartController : Controller
    {
        private readonly ChartSalesService _chartSales;

        public AdminChartController(ChartSalesService chartSales)
        {
            _chartSales = chartSales ?? throw new ArgumentNullException(nameof(chartSales));
        }

        public JsonResult SalesProducts(int days)
        {
            var productsTotalAmount = _chartSales.GetSalesProducts(days);
            return Json(productsTotalAmount);
        }

        [HttpGet]
        public IActionResult YearlySales()
        {
         

            return View();
        }

        [HttpGet]
        public IActionResult MonthlySales()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WeeklySales()
        {
            return View();
        }
    }
}
