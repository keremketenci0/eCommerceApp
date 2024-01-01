using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class SellerService : EntityBaseRepository<Seller>, ISellerService
    {
        private readonly AppDbContext _appDbContext;

        public SellerService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Seller> GetSellerByIdAsync(int id)
        {
            var sellerDetails = await _appDbContext.Sellers
                .Include(p => p.Products)
                .FirstOrDefaultAsync(n => n.Id == id);

            return sellerDetails;
        }
    }
}
