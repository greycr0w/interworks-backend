using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Interworks.API.Models;

namespace Interworks.API.Models {
     public class ApplicationDbContext : DbContext {
        public DbSet<User> users { get; set; }
        
        //public DbSet<Category> categories { get; set; }
        public DbSet<Discount> discounts { get; set; }
        
        public DbSet<Product> products { get; set; }
        
        public DbSet<Order> purchases { get; set; }

        public DbSet<Country> countries { get; set; }

        public DbSet<Template> templates { get; set; } 


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                 .SelectMany(t => t.GetProperties())
                                                 .Where(p => p.ClrType == typeof(string)))
            {
                property
                    .AsProperty()
                    .Builder
                    .HasMaxLength(256, ConfigurationSource.Convention);
            }
            
            
            modelBuilder.Entity<Country>()
                .HasIndex(a => a.code)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(a => a.country)
                .WithMany()
                .HasForeignKey(a => a.countryId);

            //one category for many products 
            modelBuilder.Entity<Category>()
                .HasMany(c => c.products)
                .WithOne(e => e.category);
            
            //many to many example
            modelBuilder.Entity<UserDiscounts>()
                .HasKey(ud => new {ud.userId , ud.discountId });  
            modelBuilder.Entity<UserDiscounts>()
                .HasOne(ud => ud.discount)
                .WithMany(d => d.userDiscounts)
                .HasForeignKey(ud => ud.discountId);  
            modelBuilder.Entity<UserDiscounts>()
                .HasOne(bc => bc.user)
                .WithMany(c => c.userDiscounts)
                .HasForeignKey(bc => bc.userId);
            
        }
    }
}