//using eCommerceApp.Data;
//using eCommerceApp.Data.Services;
//using eCommerceApp.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;

//namespace eCommerceApp.Controllers
//{
//    public class AccountController : Controller
//    {

//        private readonly ILogger<AccountController> _logger;
//        private readonly AppDbContext _appDbContext;
//        private readonly IUserService _userService;

//        public AccountController(ILogger<AccountController> logger, AppDbContext appDbContext, IUserService userService)
//        {
//            _logger = logger;
//            _appDbContext = appDbContext;
//            _userService = userService;
//        }

//        public IActionResult Register()
//        {
//            return View();
//        }

//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> RegisterUser(string firstName, string lastName, string userName, string email, string password, string confirmPassword)
//        {
//            if (!string.IsNullOrWhiteSpace(firstName) &&
//                !string.IsNullOrWhiteSpace(lastName) &&
//                !string.IsNullOrWhiteSpace(userName) &&
//                !string.IsNullOrWhiteSpace(email) &&
//                !string.IsNullOrWhiteSpace(password))
//            {

//                if (await _userService.IsEmailInUse(email))
//                {
//                    ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanımda."); // Mesajı düzenle
//                    return RedirectToAction("Register");
//                }

//                if (password != confirmPassword)
//                {
//                    ModelState.AddModelError("password", "şifreler eşleşmiyor"); // Mesajı düzenle
//                    return RedirectToAction("Register");
//                }

//                var newUser = new User
//                {
//                    FirstName = firstName,
//                    LastName = lastName,
//                    UserName = userName,
//                    Email = email,
//                    Password = password
//                };

//                await _userService.AddUser(newUser);

//                return RedirectToAction("Index", "Product");
//            }
//            return RedirectToAction("Register");
//        }

//        [HttpPost]
//        public async Task<IActionResult> LoginUser(string email, string password)
//        {
//            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
//            {
//                var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

//                if (user != null && user.Password == password)
//                {
//                    return RedirectToAction("Index", "Product");
//                }
//            }
//            ModelState.AddModelError(string.Empty, "Giriş bilgileri geçersiz.");
//            return RedirectToAction("Login");
//        }


//        // #####
//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
