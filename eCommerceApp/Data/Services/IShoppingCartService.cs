using eCommerceApp.Data.Base;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public interface IShoppingCartService : IEntityBaseRepository<ShoppingCart>
    {
        int GetShoppingCartIdByUserId(string userId);

        Task<ShoppingCart> GetShoppingCartByIdAsync(string id);
    }
}
