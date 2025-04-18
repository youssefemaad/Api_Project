using System.Reflection;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Presistence.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductType> ProductTypes {get;set;}
        public DbSet<ProductBrand> ProductBrands {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}
