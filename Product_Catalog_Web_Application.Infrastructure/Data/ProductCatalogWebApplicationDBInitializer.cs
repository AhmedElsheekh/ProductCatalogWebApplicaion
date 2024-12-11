using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Product_Catalog_Web_Application.Core.Entities.Identity;
using Product_Catalog_Web_Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Infrastructure.Data
{
    public static class ProductCatalogWebApplicationDBInitializer
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                //Get required services
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<ProductCatalogWebApplicationDBContext>();

                //Seed Admin User
                //First seed application user
                if (!userManager.Users.Any())
                {
                    var user = new ApplicationUser
                    {
                        Email = "Admin@gmail.com",
                        UserName = "Admin@gmail.com".Split('@')[0]
                    };

                    await userManager.CreateAsync(user, "P@ssw0rd");

                    //Second seed admin role
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!roleManager.Roles.Any())
                    {
                        var role = new IdentityRole
                        {
                            Name = "Admin"
                        };

                        await roleManager.CreateAsync(role);
                    }

                    //Add created user to admin role
                    await userManager.AddToRoleAsync(user, "Admin");

                    //Add the created user admin to Admins table
                    if (!dbContext.Admins.Any())
                    {
                        var admin = new Admin
                        {
                            ApplicationUserId = user.Id
                        };

                        await dbContext.AddAsync(admin);
                        await dbContext.SaveChangesAsync();
                    }
                }


                //Seed Categories
                if (!dbContext.Categories.Any())
                {
                    List<Category> categories = new List<Category>
                    {
                        new Category
                        {
                            Name = "Phones",
                            Description = "Smart phones"
                        },
                        new Category
                        {
                            Name = "Laptops",
                            Description = "New version laptops"
                        }
                    };

                    await dbContext.AddRangeAsync(categories);
                    await dbContext.SaveChangesAsync();
                }

            }
        }
    }
}
