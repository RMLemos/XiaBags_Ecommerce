﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XiaBags_Ecommerce.Areas.Admin.Services;

namespace XiaBags_Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSalesController : Controller
    {
        private readonly ReportSalesService reportSalesService;

        public AdminSalesController(ReportSalesService _reportSalesService)
        {
            reportSalesService = _reportSalesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ReportSales(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                minDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await reportSalesService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}