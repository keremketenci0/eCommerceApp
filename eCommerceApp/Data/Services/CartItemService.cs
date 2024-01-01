using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class CartItemService : EntityBaseRepository<CartItem>, ICartItemService
    {
        private readonly AppDbContext _appDbContext;

        public CartItemService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
