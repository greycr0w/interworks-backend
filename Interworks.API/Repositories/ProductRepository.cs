using Interworks.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Repositories {
    public class ProductRepository : BaseRepository<Product> {
        
        public ProductRepository(ApplicationDbContext db, DbSet<Product> dbset) : base(db, dbset) {
            
        }
    }
}