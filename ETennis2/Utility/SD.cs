using ETennis2.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETennis2.Utility
{
    public class SD
    {
        public const string Admin = "Admin";
        public const string Coach = "Coach";
        public const string Member = "Member";

        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<TennisRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<TennisUser>>();
            string[] roleNames = { Admin, Coach, Member };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //seed roles
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new TennisRole()
                    {
                        Name = roleName,
                        //NormalizedName = roleName
                    });
                }
            }

            //create admin
            var adminUser = new TennisUser()
            {
                UserName = "huang@gmail.com",
                Email = "huang@gmail.com"
            };

            string userPassword = "Password123!";
            var user = await UserManager.FindByEmailAsync("huang@gmail.com");

            if (user == null)
            {
                var createAdminUser = await UserManager.CreateAsync(adminUser, userPassword);
                if (createAdminUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(adminUser, Admin);
                }
            }

            var coach1 = await UserManager.FindByEmailAsync("coach1@gmail.com");
            if (coach1 == null)
            {
                var newCoach = new TennisUser() { UserName = "coach1@gmail.com", Email = "coach1@gmail.com" };
                var createCoach = await UserManager.CreateAsync(newCoach, "Password1!");
                if (createCoach.Succeeded)
                {
                    await UserManager.AddToRoleAsync(newCoach, Coach);
                }
            }

            var coach2 = await UserManager.FindByEmailAsync("coach2@gmail.com");
            if (coach2 == null)
            {
                var newCoach = new TennisUser() { UserName = "coach2@gmail.com", Email = "coach2@gmail.com" };
                var createCoach = await UserManager.CreateAsync(newCoach, "Password2!");
                if (createCoach.Succeeded)
                {
                    await UserManager.AddToRoleAsync(newCoach, Coach);
                }
            }
        }
    }
}
