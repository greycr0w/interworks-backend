using Interworks.API.Entities;
using Interworks.API.Interfaces;

namespace Interworks.API.Repositories {
    public class SoftDeleteRepository : BaseRepository<ISoftDeletePrimaryEntity> {
        
        public SoftDeleteRepository(ApplicationDbContext db) : base(db) {
            
        }
        
    }
}