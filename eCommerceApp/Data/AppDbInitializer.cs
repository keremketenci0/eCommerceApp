using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Models;

namespace eCommerceApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                appDbContext.Database.EnsureCreated();

                // Seller
                if (!appDbContext.Sellers.Any())
                {
                    appDbContext.Sellers.AddRange(new List<Seller>()
                    {
                        new Seller()
                        {
                            Name = "ElectronicSeller"
                        },
                        new Seller()
                        {
                            Name = "SportSeller"
                        },
                        new Seller()
                        {
                            Name = "ToySeller"
                        },
                        new Seller()
                        {
                            Name = "ShoeSeller"
                        },
                        new Seller()
                        {
                            Name = "BeautySeller"
                        },
                    });
                    appDbContext.SaveChanges();
                }

                // Category
                if (!appDbContext.Categories.Any())
                {
                    appDbContext.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Electronics",
                            Image = "img/categories/electronics/electronic.jpg"
                        },
                        new Category()
                        {
                            Name = "Sports",
                            Image = "img/categories/sports/sport.jpg"
                        },
                        new Category()
                        {
                            Name = "Toys",
                            Image = "img/categories/toys/toy.jpg"
                        },
                        new Category()
                        {
                            Name = "Fashion",
                            Image = "img/categories/fashions/fashion.jpg"
                        },
                        new Category()
                        {
                            Name = "Beauty",
                            Image = "img/categories/beautys/beauty.jpg"
                        },
                    });
                    appDbContext.SaveChanges();
                }

                // Product
                if (!appDbContext.Products.Any())
                {
                    appDbContext.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Camera1",
                            Price = 99.99,
                            Image = "img/products/electronics/cameras/camera1_1.jpg",


                            CategoryId = 1,
                            SellerId = 1,
                        },
                        new Product()
                        {
                            Name = "Headphone1",
                            Price = 199.99,
                            Image = "img/products/electronics/headphones/headphone1_1.jpg",

                            CategoryId = 1,
                            SellerId = 1,
                        },
                        new Product()
                        {
                            Name = "Watch1",
                            Price = 299.99,
                            Image = "img/products/electronics/watchs/watch1_1.jpg",

                            CategoryId = 1,
                            SellerId = 1,
                        },
                        new Product()
                        {
                            Name = "Watch2",
                            Price = 399.99,
                            Image = "img/products/electronics/watchs/watch2_1.jpg",

                            CategoryId = 1,
                            SellerId = 1,
                        },

                        new Product()
                        {
                            Name = "Basketball1",
                            Price = 499.99,
                            Image = "img/products/sports/Basketballs/Basketball1_1.jpg",

                            CategoryId = 2,
                            SellerId = 2,
                        },
                        new Product()
                        {
                            Name = "Figure1",
                            Price = 599.99,
                            Image = "img/products/toys/figures/figure1_1.jpg",

                            CategoryId = 3,
                            SellerId = 3,
                        },
                        new Product()
                        {
                            Name = "Shoe1",
                            Price = 699.99,
                            Image = "img/products/fashion/shoes/shoe1_1.jpg",

                            CategoryId = 4,
                            SellerId = 4,
                        },
                        new Product()
                        {
                            Name = "Shoe2",
                            Price = 799.99,
                            Image = "img/products/fashion/shoes/shoe2_1.jpg",

                            CategoryId = 4,
                            SellerId = 4,
                        },
                        new Product()
                        {
                            Name = "Shoe3",
                            Price = 899.99,
                            Image = "img/products/fashion/shoes/shoe3_1.jpg",

                            CategoryId = 4,
                            SellerId = 4,
                        },
                        new Product()
                        {
                            Name = "Shoe4",
                            Price = 999.99,
                            Image = "img/products/fashion/shoes/shoe4_1.jpg",

                            CategoryId = 4,
                            SellerId = 4,
                        },
                        new Product()
                        {
                            Name = "Shoe5",
                            Price = 1099.99,
                            Image = "img/products/fashion/shoes/shoe5_1.jpg",

                            CategoryId = 4,
                            SellerId = 4,
                        },
                         new Product()
                        {
                            Name = "Cream1",
                            Price = 1199.99,
                            Image = "img/products/beauty/creams/cream1_1.jpg",

                            CategoryId = 5,
                            SellerId = 5,
                        },
                    });
                    appDbContext.SaveChanges();
                }
            }
        }
    }
}