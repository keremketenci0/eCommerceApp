using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly AppDbContext _appDbContext;

        public ProductService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _appDbContext.Products
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }
    }
}
