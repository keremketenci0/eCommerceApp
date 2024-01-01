using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        /// <summary>
        //public DbSet<User> Users { get; set; }
        // #####
        public DbSet<Seller> Sellers { get; set; }
        // #####
        public DbSet<Category> Categories { get; set; }
        // #####
        public DbSet<Product> Products { get; set; }
        // #####
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        // #####
        public DbSet<Order> Orders { get; set; }

        /// </summary>
    }
}
