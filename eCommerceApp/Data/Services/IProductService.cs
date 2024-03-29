﻿using eCommerceApp.Data.Base;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}
