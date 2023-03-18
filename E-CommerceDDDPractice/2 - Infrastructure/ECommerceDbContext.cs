using _1___Domain.Authentication.Entities;
using _1___Domain.Categories.Entities;
using _1___Domain.Orders.Entities;
using _1___Domain.Products.Entities;
using _2___Infrastructure.Authentication.Configuration;
using _2___Infrastructure.Categories.Configuration;
using _2___Infrastructure.Orders.Configuration;
using _2___Infrastructure.Products.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2___Infrastructure
{
    public class ECommerceDbContext: IdentityDbContext<User>
    {
        public ECommerceDbContext(
            DbContextOptions<ECommerceDbContext> options) 
            :base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            builder.Entity<User>().ToTable("Users", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Identity");
            builder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Identity");
        }
    }
}
