using Interworks.API.Models;

namespace Interworks.API.Services {
    public class ProductService : BaseRepositoryAsyncService<Product> {
        
        public ProductService(ApplicationDbContext db) : base(db, db.products) {
            
        }
        
    }
}