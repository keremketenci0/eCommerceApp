using eCommerceApp.Data.Base;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public interface ICategoryService : IEntityBaseRepository<Category>
    {
        Task<Category> GetCategoryByIdAsync(int id);
    }
}
