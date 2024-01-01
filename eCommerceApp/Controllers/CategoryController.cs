using System.Diagnostics;
using eCommerceApp.Data.Services;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _service;

        public CategoryController(ILogger<HomeController> logger, ICategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoryDetail = await _service.GetCategoryByIdAsync(id);
            return View(categoryDetail);
        }
    }
}