using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Presistence.Data.Identity
{
    public class StoreIdentityDbContex(DbContextOptions<StoreIdentityDbContex> options) : IdentityDbContext<ApplicationUser>(options)
    {
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
        }
    }
}
