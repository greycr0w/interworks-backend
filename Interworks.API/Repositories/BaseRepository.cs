using System;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Interfaces;
using Interworks.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Repositories {
    public class BaseRepository<T> : IRepositoryAsync<T> where T : class, IPrimaryModel {
        protected readonly ApplicationDbContext db;

        protected readonly DbSet<T> dbset;
        
        public BaseRepository(ApplicationDbContext db, DbSet<T> dbset) {
            this.db = db;
            this.dbset = dbset;
        }
        
        public IQueryable<T> find() {
            return dbset.AsQueryable();
        }
        
        public async Task<T> findAsync(Guid id) {
            var tObject = await dbset.SingleAsync(a => a.id == id);
            return tObject;
        }

        public async Task<bool> deleteAsync(Guid id) {
            try {
                
                // this happens on db DELETE FROM tobject WHERE this.id = id
                dbset.RemoveRange(
                    dbset.Where(a => a.id == id)
                );

                // return true if user is deleted
                // return false if user was not in db already
                return await db.SaveChangesAsync() == 1;
            }
            catch (DbUpdateException inv) {
                throw new Exception("Can not process your delete request", inv);
            }
        }

        public async Task<T> createAsync(T tObject) {
            tObject.createdAt = DateTimeOffset.Now;
            await dbset.AddAsync(tObject);
            await db.SaveChangesAsync();
            return tObject;
        }

        public async Task<T> updateAsync(T tObjext) {
            tObjext.updatedAt = DateTimeOffset.Now;
            dbset.Update(tObjext);
            await db.SaveChangesAsync();
            return tObjext;
        }
    }
}