using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Repositories {
    public class UserRepository : BaseRepository<User> {
        public UserRepository(ApplicationDbContext db) : base(db) {
            
        }
    }
}