using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Paycompute.Persistence
{
    public static class DataSeedingInitializer
    {
        public static async Task UserAndRoleSeedAsync(UserManager<IdentityUser> userManager,
                                                RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Manager", "Staff" };
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //Create Admin User
            if (userManager.FindByEmailAsync("ak42549@ubt-uni.net").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "ak42549@ubt-uni.net",
                    Email = "ak42549@ubt-uni.net"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            //Create Manager User
            if (userManager.FindByEmailAsync("az41597@ubt-uni.net").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "az41597@ubt-uni.net",
                    Email = "az41597@ubt-uni.net"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            //Create Staff User
            if (userManager.FindByEmailAsync("fm41566@ubt-uni.net").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "fm41566@ubt-uni.net",
                    Email = "fm41566@ubt-uni.net"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();
                }
            }

            //Create No Role User
            if (userManager.FindByEmailAsync("shki@ubt-uni.net").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "shki@ubt-uni.net",
                    Email = "shki@ubt-uni.net"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                // No Role assigned to ShKI
            }
        }
    }
}
