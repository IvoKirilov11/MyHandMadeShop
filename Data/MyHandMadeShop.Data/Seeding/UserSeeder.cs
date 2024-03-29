﻿namespace MyHandMadeShop.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using MyHandMadeShop.Common;
    using MyHandMadeShop.Data.Models;

    public class UserSeeder : ISeeder
    {
        private const string UsersPassword = "123456";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (userManager.Users.Count() > 1)
            {
                return;
            }

            var admin = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@myemail.com",
                EmailConfirmed = true,
            };

            var client = new ApplicationUser()
            {
                UserName = "Client",
                Email = "client@bmail.com",
                EmailConfirmed = true,
            };

            await SeedUser(userManager, admin, UsersPassword, GlobalConstants.AdministratorRoleName);
            await SeedUser(userManager, client, UsersPassword, GlobalConstants.ClientRoleName);
        }

        private static async Task SeedUser(UserManager<ApplicationUser> userManager, ApplicationUser user, string password, string roleName)
        {
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
