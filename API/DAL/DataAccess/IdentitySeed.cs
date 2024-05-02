using API.DAL.Models.Data;
using Microsoft.AspNetCore.Identity;

namespace API.DAL.DataAccess
{
    public static class IdentitySeed
    {
        public static async Task GenerateUserRoles(IServiceProvider serviceProvider)
        {
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();


            if (await rolesManager.FindByNameAsync("admin") == null)
            {
                await rolesManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await rolesManager.FindByNameAsync("user") == null)
            {
                await rolesManager.CreateAsync(new IdentityRole("user"));
            }

            string userName = "user";
            string userPassword = "Aa123456!";
            var usr = await userManager.FindByNameAsync(userName);
            if (usr == null)
            {
                User user = new User { UserName = userName };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
            string adminUsername = "admin";
            string adminPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                User admin = new User { UserName = adminUsername };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
