using System.Text.Json;
using DomainLayer.Contracts;
using DomainLayer.Models;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Data.Identity;

namespace Presistence
{
    public class DataSeeding(StoreDbContext _dbContext, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager,
    StoreIdentityDbContex _identityDbContex) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                // Apply pending migrations if any
                if ((await _dbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }

                // Seed ProductBrands
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandsData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeed\brands.json");
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandsData);

                    if (ProductBrands is not null && ProductBrands.Any())
                    {
                        await _dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                    }
                }

                // Seed ProductTypes
                if (!_dbContext.ProductTypes.Any())
                {
                    var ProductTypesData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeed\types.json");
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypesData);

                    if (ProductTypes is not null && ProductTypes.Any())
                    {
                        await _dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                    }
                }
                // Seed Products
                if (!_dbContext.Products.Any())
                {
                    var ProductsData = File.OpenRead(@"..\Infrastructure\Presistence\Data\DataSeed\products.json");
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductsData);

                    if (Products is not null && Products.Any())
                    {
                        await _dbContext.Products.AddRangeAsync(Products);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during data seeding: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public async Task IdentityDataSeedAsync()
        {
            try
            {
                if(!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }

                if (!_userManager.Users.Any())
                {
                    var User01 = new ApplicationUser
                    {
                        Email = "eyoussef228@gmail.com",
                        DisplayName = "Youssef",
                        PhoneNumber = "01000000000",
                        UserName = "youssefeemad"
                    };
                    var User02 = new ApplicationUser
                    {
                        Email = "youssefeemad2@gmail.com",
                        DisplayName = "Adham",
                        PhoneNumber = "01000000001",
                        UserName = "Adhameemad"
                    };
                
                    await _userManager.CreateAsync(User01, "Password@123");
                    await _userManager.CreateAsync(User02, "Password@123");

                    await _userManager.AddToRoleAsync(User01, "Admin");
                    await _userManager.AddToRoleAsync(User02, "SuperAdmin");
                }

                await _identityDbContex.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during identity data seeding: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
