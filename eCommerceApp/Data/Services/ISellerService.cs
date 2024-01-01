using eCommerceApp.Data.Base;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public interface ISellerService : IEntityBaseRepository<Seller>
    {
        Task<Seller> GetSellerByIdAsync(int id);
    }
}
