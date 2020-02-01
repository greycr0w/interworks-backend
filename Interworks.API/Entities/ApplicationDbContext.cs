using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Interworks.API.Entities.Part1;
using Interworks.API.Entities.Part2;
using Interworks.API.Entities;


namespace Interworks.API.Entities {
     public class ApplicationDbContext : DbContext {
             
        public virtual DbSet<Category> categories { get; set; }
        
        public virtual DbSet<Country> countries { get; set; }

        public virtual DbSet<Discount> discounts { get; set; }
        
        public virtual DbSet<Order> orders { get; set; }
        
        public virtual DbSet<Product> products { get; set; }
        
        public virtual DbSet<ProductDiscount> productDiscounts { get; set; }
        
        public virtual DbSet<Template> templates { get; set; } 

        public virtual DbSet<UsedDiscount> usedDiscounts { get; set; }
        
        public virtual DbSet<Data> datum { get; set; }
        
        public virtual DbSet<Field> fields { get; set; }
        
        public virtual DbSet<FieldOption> fieldOptions { get; set; }
        
        public virtual DbSet<Page> pages { get; set; }
        public virtual DbSet<User> users { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            modelBuilder.Entity<Page>()
                .HasMany(a => a.fields)
                .WithOne(b => b.page)
                .HasForeignKey(c => c.pageId);
            
            
            
            modelBuilder.Entity<UsedDiscount>()
                .HasKey(ad => new {ad.userId, ad.discountId});

            modelBuilder.Entity<UsedDiscount>()
                .HasOne(a => a.discount)
                .WithMany(b => b.usedDiscounts)
                .HasForeignKey(c => c.discountId);
            
            modelBuilder.Entity<UsedDiscount>()
                .HasOne(a => a.user)
                .WithMany(b => b.usedDiscounts)
                .HasForeignKey(c => c.userId);

            
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
                .WithOne(e => e.category)
                .HasForeignKey(c => c.categoryId);
            
            //many to many example
            modelBuilder.Entity<ProductDiscount>()
                .HasKey(ud => new {ud.productId , ud.discountId });  
            modelBuilder.Entity<ProductDiscount>()
                .HasOne(ud => ud.discount)
                .WithMany(d => d.productDiscounts)
                .HasForeignKey(ud => ud.discountId);  
            modelBuilder.Entity<ProductDiscount>()
                .HasOne(bc => bc.product)
                .WithMany(c => c.productDiscounts)
                .HasForeignKey(bc => bc.productId);
        }
    }
}