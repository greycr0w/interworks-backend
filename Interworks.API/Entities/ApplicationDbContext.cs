using System;
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



            modelBuilder.Entity<Order>()
                .HasOne(a => a.product)
                .WithMany()
                .HasForeignKey(a => a.productId);
            
            modelBuilder.Entity<User>()
                .HasMany(a => a.datum)
                .WithOne(b => b.user)
                .HasForeignKey(c => c.userId);
            
            modelBuilder.Entity<User>()
                .HasMany(a => a.orders)
                .WithOne(b => b.user)
                .HasForeignKey(c => c.userId);
            
            modelBuilder.Entity<FieldOption>()
                .HasMany(a => a.datum)
                .WithOne()
                .HasForeignKey(d => d.fieldOptionId);
            
            modelBuilder.Entity<Data>()
                .HasOne(a => a.user)
                .WithMany(c => c.datum)
                .HasForeignKey(d => d.userId);

            modelBuilder.Entity<Data>()
                .HasOne(a => a.field)
                .WithMany(c => c.datum)
                .HasForeignKey(b => b.fieldId);
            
            modelBuilder.Entity<Page>()
                .HasMany(a => a.fields)
                .WithOne(b => b.page)
                .HasForeignKey(c => c.pageId);
            
              
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
            
            
            
            //INSERTS
            
            
            modelBuilder.Entity<User>().HasData(
                new User() { id  = Guid.NewGuid(), username = "test", password = "test", type = UserType.USER },
                new User() { id  = Guid.NewGuid(), username = "test", password = "test", type = UserType.CLIENT }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product() { id  = Guid.NewGuid(), name = "Product Name", price = 340, description = "This is a sample subscription product", cycle = 6}
                
            );
        }
    }
}