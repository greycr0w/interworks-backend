using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Interworks.API.Models;

namespace Interworks.API.Models {
     public class ApplicationDbContext : DbContext {
        public DbSet<User> users { get; set; }
        
        //public DbSet<Category> categories { get; set; }

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
            
            
        }
    }
}