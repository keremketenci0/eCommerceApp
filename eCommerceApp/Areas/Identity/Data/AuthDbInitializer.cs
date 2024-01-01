using Microsoft.AspNetCore.Identity;
using eCommerceApp.Constants;

namespace eCommerceApp.Areas.Identity.Data
{
    public static class AuthDbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<AppUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // creating admin

            var user = new AppUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "AdminF",
                LastName = "AdminL",
                EmailConfirmed = true,
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin123+");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }

    }
}
