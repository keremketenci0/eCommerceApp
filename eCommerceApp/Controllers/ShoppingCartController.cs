using System.Security.Claims;
using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Data;
using eCommerceApp.Data.Services;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace eCommerceApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _service;
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthDbContext _authDbContext;
        private readonly AppDbContext _appDbContext;

        public ShoppingCartController(IShoppingCartService service,
                                        UserManager<AppUser> userManager, 
                                        AuthDbContext authDbContext, 
                                        AppDbContext appDbContext)
        {
            _service = service;
            this._userManager = userManager;
            _authDbContext = authDbContext;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index() 
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCart = await _appDbContext.ShoppingCarts.FirstOrDefaultAsync(cart => cart.AppUserId == userId);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    AppUserId = userId
                };

                _appDbContext.ShoppingCarts.Add(shoppingCart);
                await _appDbContext.SaveChangesAsync();
            }

            ViewData["UserId"] = userId;

            var data = await _service.GetAllAsync(c => c.CartItems);
			return View(data);
        }

        public async Task<IActionResult> Details(string id)
        {
            var shoppingCartDetail = await _service.GetShoppingCartByIdAsync(id);
            return View(shoppingCartDetail);
        }

        public async Task<IActionResult> CreateUserCart()
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCart = await _appDbContext.ShoppingCarts.FirstOrDefaultAsync(cart => cart.AppUserId == userId);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    AppUserId = userId
                };

                _appDbContext.ShoppingCarts.Add(shoppingCart);
                await _appDbContext.SaveChangesAsync();
            }

            ViewData["UserId"] = userId;

            return View();
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCart = await _appDbContext.ShoppingCarts.FirstOrDefaultAsync(cart => cart.AppUserId == userId);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    AppUserId = userId
                };

                _appDbContext.ShoppingCarts.Add(shoppingCart);
                await _appDbContext.SaveChangesAsync();
            }

            ViewData["UserId"] = userId;


            var shoppingCartId = _service.GetShoppingCartIdByUserId(userId);

            var cartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(cart => cart.ShoppingCartId == shoppingCartId);

            if (shoppingCartId != null)
            {
                var existingCartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(item => item.ProductId == id && item.ShoppingCartId == shoppingCartId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += 1;
                }
                else
                {
                    cartItem = new CartItem
                    {
                        ShoppingCartId = shoppingCartId,
                        ProductId = id,
                        Quantity = 1
                    };
                    _appDbContext.CartItems.Add(cartItem);
                }
                
                await _appDbContext.SaveChangesAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> EmptyShoppingCart(string id)
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCart = await _appDbContext.ShoppingCarts
                .Include(cart => cart.CartItems)
                .FirstOrDefaultAsync(cart => cart.AppUserId == userId);

            if (shoppingCart != null)
            {
                _appDbContext.CartItems.RemoveRange(shoppingCart.CartItems); // Remove all CartItems
                await _appDbContext.SaveChangesAsync();

                _appDbContext.ShoppingCarts.Remove(shoppingCart); // Remove the Shopping Cart itself
                await _appDbContext.SaveChangesAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Increase(int id)
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCart = await _appDbContext.ShoppingCarts.FirstOrDefaultAsync(cart => cart.AppUserId == userId);

            var shoppingCartId = _service.GetShoppingCartIdByUserId(userId);

            var cartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(cart => cart.ShoppingCartId == shoppingCartId);

            if (shoppingCartId != null)
            {
                var existingCartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(item => item.ProductId == id && item.ShoppingCartId == shoppingCartId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += 1;
                }

                await _appDbContext.SaveChangesAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCart = await _appDbContext.ShoppingCarts.FirstOrDefaultAsync(cart => cart.AppUserId == userId);

            var shoppingCartId = _service.GetShoppingCartIdByUserId(userId);

            var cartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(cart => cart.ShoppingCartId == shoppingCartId);

            if (shoppingCartId != null)
            {
                var existingCartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(item => item.ProductId == id && item.ShoppingCartId == shoppingCartId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity -= 1;

                    if (existingCartItem.Quantity == 0)
                    {
                        _appDbContext.CartItems.Remove(existingCartItem);
                    }
                }

                await _appDbContext.SaveChangesAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> DeleteItem(int id)
        {
            var userId = _userManager.GetUserId(this.User);

            var shoppingCartId = _service.GetShoppingCartIdByUserId(userId);

            if (shoppingCartId != null)
            {
                var existingCartItem = await _appDbContext.CartItems.FirstOrDefaultAsync(item => item.ProductId == id && item.ShoppingCartId == shoppingCartId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity = 0;

                    if (existingCartItem.Quantity == 0)
                    {
                        _appDbContext.CartItems.Remove(existingCartItem);
                    }

                    await _appDbContext.SaveChangesAsync();
                }
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
