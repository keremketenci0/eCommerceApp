//using eCommerceApp.Models;
//using Microsoft.EntityFrameworkCore;

//namespace eCommerceApp.Data.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly AppDbContext _appDbContext;

//        public UserService(AppDbContext appDbContext)
//        {
//            _appDbContext = appDbContext;
//        }

//        // Add new user
//        public async Task<User> AddUser(User user)
//        {
//            if (user is not null)
//            {
//                await _appDbContext.Users.AddAsync(user);
//                await _appDbContext.SaveChangesAsync();
//            }
//            return user;
//        }

//        public List<string> GetAllEmails()
//        {
//            List<string> emails = _appDbContext.Users.Select(u => u.Email).ToList();

//            return emails;
//        }

//        public async Task<bool> IsEmailInUse(string email)
//        {
//            return await _appDbContext.Users.AnyAsync(u => u.Email == email);
//        }
//    }
//}