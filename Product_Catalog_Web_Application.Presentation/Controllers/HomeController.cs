using Microsoft.AspNetCore.Mvc;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Core.ViewModels;
using Product_Catalog_Web_Application.Presentation.Models;
using System.Diagnostics;

namespace Product_Catalog_Web_Application.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger,
			IProductService productService)
		{
			_logger = logger;
            _productService = productService;
        }

		public async Task<IActionResult> Index(string? search)
		{
			if(!string.IsNullOrEmpty(search))
			{
				var productsByCategory = _productService.GetByCategory(search).Data;
				return View(productsByCategory);
			}

			var products = (await _productService.GetCurrentAsync()).Data;
			return View(products);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
