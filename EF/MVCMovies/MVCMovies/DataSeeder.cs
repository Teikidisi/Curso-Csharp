using Microsoft.AspNetCore.Identity;
using MVCMovies.Models;

namespace MVCMovies
{
    public class DataSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.Administrator.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Role.User.ToString()));
            }
        }
    }
}
