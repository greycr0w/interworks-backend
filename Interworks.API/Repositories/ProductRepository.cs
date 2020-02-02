using Interworks.API.Entities;
using Interworks.API.Entities.Part1;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Repositories {
    public class ProductRepository : BaseRepository<Product> {
        
        public ProductRepository(ApplicationDbContext db) : base(db) {
            
        }
    }
}