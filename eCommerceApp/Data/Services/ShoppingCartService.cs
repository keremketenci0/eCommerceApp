using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using eCommerceApp.Data.Base;


namespace eCommerceApp.Data.Services
{
    public class ShoppingCartService : EntityBaseRepository<ShoppingCart>, IShoppingCartService
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCartService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(string id)
        {
            var shoppingCartDetails = await _appDbContext.ShoppingCarts
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync(n => n.AppUserId == id);

            return shoppingCartDetails;
        }

        public int GetShoppingCartIdByUserId(string userId)
        {
            var shoppingCart = _appDbContext.ShoppingCarts
                .FirstOrDefault(cart => cart.AppUserId == userId);

            return shoppingCart?.Id ?? 0;
        }
    }
}
