using eCommerceApp.Data;
using eCommerceApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService _service;

        public SellerController(ISellerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(p => p.Products);
            return View(data);
        }

		public async Task<IActionResult> Details(int id)
		{
			var sellerDetail = await _service.GetSellerByIdAsync(id);
			return View(sellerDetail);
		}
	}
}
