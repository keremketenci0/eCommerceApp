using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Constants;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _appDbContext;
        private readonly AuthDbContext _authDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;

        public AdminService(AppDbContext appDbContext, AuthDbContext authDbContext, UserManager<AppUser> userManager, IUserStore<AppUser> userStore)
        {
            _appDbContext = appDbContext;
            _authDbContext = authDbContext;
            _userManager = userManager;
            _userStore = userStore;
        }

        public IQueryable<AppUser> GetUsers()
        {
            IQueryable<AppUser> allUsers = _authDbContext.Users;
            return allUsers;
        }

        public AppUser DetailsUser(string id)
        {

            var user = _authDbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<AppUser> AddUser(UserPostRequest userPostRequest, string password)
        {
            // Create an AppUser object from the received UserPostRequest
            AppUser newUser = new AppUser
            {
                FirstName = userPostRequest.FirstName,
                LastName = userPostRequest.LastName,
                Email = userPostRequest.Email,
                UserName = userPostRequest.Email, // Set UserName to Email for simplicity, adjust as needed
                EmailConfirmed = true // Set EmailConfirmed to true
            };

            // Normalize UserName and Email manually
            newUser.NormalizedUserName = _userManager.NormalizeName(newUser.UserName);
            newUser.NormalizedEmail = _userManager.NormalizeEmail(newUser.Email);

            // Hash and set the user's password
            var passwordHasher = new PasswordHasher<AppUser>();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, password);

            await _authDbContext.Users.AddAsync(newUser);
            await _authDbContext.SaveChangesAsync();

            await _userManager.AddToRoleAsync(newUser, Roles.User.ToString());
            await _authDbContext.SaveChangesAsync();

            return newUser;
        }



        public async Task<AppUser> UpdateUser(UserPutRequest userPutRequest, string id)
        {
            // Get the user to update
            var userDetails = DetailsUser(id);

            if (userDetails != null)
            {
                userDetails.FirstName = userPutRequest.FirstName;
                userDetails.LastName = userPutRequest.LastName;
                userDetails.Email = userPutRequest.Email;
                userDetails.UserName = userPutRequest.Email;
                userDetails.ModifiedAt = DateTime.UtcNow.AddHours(3);

                userDetails.NormalizedUserName = _userManager.NormalizeName(userPutRequest.Email);
                userDetails.NormalizedEmail = _userManager.NormalizeEmail(userPutRequest.Email);

                await _userManager.UpdateAsync(userDetails);
                await _authDbContext.SaveChangesAsync();
            }
            return userDetails;
        }



        public bool DeleteUser(string id)
        {
            var user = DetailsUser(id);

            if (user != null)
            {
                _authDbContext.Users.Remove(user);
                _authDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<AppUser> TakeUsers(IQueryable<AppUser> query, int? count)
        {

            if (count.HasValue && count >= 0)
            {
                int countValue = count.Value; // Convert nullable int to non-nullable int
                query = query.Take(countValue);
            }

            return query;
        }

        public IQueryable<AppUser> FilterUsers(IQueryable<AppUser> query, string? firstName, string? lastName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(u => u.FirstName == firstName);
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(u => u.LastName == lastName);
            }

            return query;
        }

        public IQueryable<AppUser> UserStatus(IQueryable<AppUser> query, bool? userStatus)
        {

            if (userStatus != null)
            {
                if (userStatus == true)
                {
                    query = query.Where(u => u.Status == userStatus);
                }
                if (userStatus == false)
                {
                    query = query.Where(u => u.Status == userStatus);
                }
                return query;
            }
            else
            {
                query = GetUsers();
            }
            return query;
        }
    }
}
