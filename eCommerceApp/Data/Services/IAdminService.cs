using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public interface IAdminService
    {
        IQueryable<AppUser> GetUsers();
        AppUser DetailsUser(string id);
        Task<AppUser> AddUser(UserPostRequest userPostRequest, string password);
        Task<AppUser> UpdateUser(UserPutRequest userPutRequest, string id);
        bool DeleteUser(string id);
        public IQueryable<AppUser> TakeUsers(IQueryable<AppUser> query, int? count);
        public IQueryable<AppUser> FilterUsers(IQueryable<AppUser> query, string? firstName, string? lastName);
        public IQueryable<AppUser> UserStatus(IQueryable<AppUser> query, bool? userStatus);
    }
}
