using Interworks.API.Interfaces;
using Interworks.API.Models;

namespace Interworks.API.Repositories {
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository  {
        public DiscountRepository(ApplicationDbContext db) : base(db, db.discounts) {
            
        }
    }
}