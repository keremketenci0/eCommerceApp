using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly AppDbContext _appDbContext;

        public CategoryService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var categoryDetails = await _appDbContext.Categories
                .Include(p => p.Products)
                .FirstOrDefaultAsync(n => n.Id == id);

            return categoryDetails;
        }
    }
}
