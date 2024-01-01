using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Data;
using eCommerceApp.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(UserManager<AppUser> userManager, IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(s => s.Seller);
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
    }
}
